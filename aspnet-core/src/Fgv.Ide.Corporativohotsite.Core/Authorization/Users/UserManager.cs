using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Abp;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Localization;
using Abp.Organizations;
using Abp.Runtime.Caching;
using Abp.Threading;
using Abp.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Fgv.Ide.Corporativohotsite.Authorization.Roles;
using Fgv.Ide.Corporativohotsite.Configuration;

namespace Fgv.Ide.Corporativohotsite.Authorization.Users
{
    /// <summary>
    /// User manager.
    /// Used to implement domain logic for users.
    /// Extends <see cref="AbpUserManager{TRole,TUser}"/>.
    /// </summary>
    public class UserManager : AbpUserManager<Role, User>
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly ILocalizationManager _localizationManager;
        private readonly IAppConfigurationAccessor _appConfigurationAccessor;

		public UserManager(
			UserStore userStore,
			IOptions<IdentityOptions> optionsAccessor,
			IPasswordHasher<User> passwordHasher,
			IEnumerable<IUserValidator<User>> userValidators,
			IEnumerable<IPasswordValidator<User>> passwordValidators,
			ILookupNormalizer keyNormalizer,
			IdentityErrorDescriber errors,
			IServiceProvider services,
			ILogger<UserManager> logger,
			RoleManager roleManager,
			IPermissionManager permissionManager,
			IUnitOfWorkManager unitOfWorkManager,
			ICacheManager cacheManager,
			IRepository<OrganizationUnit, long> organizationUnitRepository,
			IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository,
			IOrganizationUnitSettings organizationUnitSettings,
			ISettingManager settingManager,
			ILocalizationManager localizationManager, IAppConfigurationAccessor appConfigurationAccessor)
			: base(
				  roleManager,
				  userStore,
				  optionsAccessor,
				  passwordHasher,
				  userValidators,
				  passwordValidators,
				  keyNormalizer,
				  errors,
				  services,
				  logger,
				  permissionManager,
				  unitOfWorkManager,
				  cacheManager,
				  organizationUnitRepository,
				  userOrganizationUnitRepository,
				  organizationUnitSettings,
				  settingManager)
		{
			_unitOfWorkManager = unitOfWorkManager;
			_localizationManager = localizationManager;
			_appConfigurationAccessor = appConfigurationAccessor;
		}

		[UnitOfWork]
		public virtual async Task<User> GetUserOrNullAsync(UserIdentifier userIdentifier)
		{
			using (_unitOfWorkManager.Current.SetTenantId(userIdentifier.TenantId))
			{
				return await FindByIdAsync(userIdentifier.UserId.ToString());
			}
		}

		public User GetUserOrNull(UserIdentifier userIdentifier)
		{
			return AsyncHelper.RunSync(() => GetUserOrNullAsync(userIdentifier));
		}

		public async Task<User> GetUserAsync(UserIdentifier userIdentifier)
		{
			var user = await GetUserOrNullAsync(userIdentifier);
			if (user == null)
			{
				throw new Exception("There is no user: " + userIdentifier);
			}

			return user;
		}

		public User GetUser(UserIdentifier userIdentifier)
		{
			return AsyncHelper.RunSync(() => GetUserAsync(userIdentifier));
		}

		public override Task<IdentityResult> SetRoles(User user, string[] roleNames)
		{
			if (user.Name == "admin" && !roleNames.Contains(StaticRoleNames.Host.Admin))
			{
				throw new UserFriendlyException(L("AdminRoleCannotRemoveFromAdminUser"));
			}

			return base.SetRoles(user, roleNames);
		}

		public override async Task SetGrantedPermissionsAsync(User user, IEnumerable<Permission> permissions)
		{
			CheckPermissionsToUpdate(user, permissions);

			await base.SetGrantedPermissionsAsync(user, permissions);
		}

		private void CheckPermissionsToUpdate(User user, IEnumerable<Permission> permissions)
		{
			if (user.Name == AbpUserBase.AdminUserName &&
				(!permissions.Any(p => p.Name == AppPermissions.Pages_Administration_Roles_Edit) ||
				!permissions.Any(p => p.Name == AppPermissions.Pages_Administration_Users_ChangePermissions)))
			{
				throw new UserFriendlyException(L("YouCannotRemoveUserRolePermissionsFromAdminUser"));
			}
		}

		public bool UsuarioInternoENaoPadraoParaImpersonate(string nomeUsuario)
		{
			if (_appConfigurationAccessor.Configuration["UsuarioPadraoParaImpersonate"] == nomeUsuario)
				return false;

			var usuario = AsyncHelper.RunSync(() => Store.FindByNameAsync(nomeUsuario, CancellationToken.None));
			if (usuario != null)
				return true;

			return false;
		}

		private new string L(string name)
		{
			return _localizationManager.GetString(CorporativohotsiteConsts.LocalizationSourceName, name);
		}
	}
}
