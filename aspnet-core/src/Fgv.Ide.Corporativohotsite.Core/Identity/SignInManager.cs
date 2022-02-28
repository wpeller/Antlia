using Abp.Authorization;
using Abp.Configuration;
using Abp.Domain.Uow;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Fgv.Ide.Corporativohotsite.Authorization.Roles;
using Fgv.Ide.Corporativohotsite.Authorization.Users;
using Fgv.Ide.Corporativohotsite.MultiTenancy;

namespace Fgv.Ide.Corporativohotsite.Identity
{
    public class SignInManager : AbpSignInManager<Tenant, Role, User>
    {
        public SignInManager(
            UserManager userManager, 
            IHttpContextAccessor contextAccessor,
            UserClaimsPrincipalFactory claimsFactory, 
            IOptions<IdentityOptions> optionsAccessor, 
            ILogger<SignInManager<User>> logger,
            IUnitOfWorkManager unitOfWorkManager,
            ISettingManager settingManager,
            IAuthenticationSchemeProvider schemes
            ) : base(
                userManager, 
                contextAccessor, 
                claimsFactory, 
                optionsAccessor, 
                logger,
                unitOfWorkManager,
                settingManager,
                schemes)
        {
        }
    }
}
