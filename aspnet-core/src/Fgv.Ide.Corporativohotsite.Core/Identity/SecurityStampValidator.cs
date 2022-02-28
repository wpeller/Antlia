using Abp.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Fgv.Ide.Corporativohotsite.Authorization.Roles;
using Fgv.Ide.Corporativohotsite.Authorization.Users;
using Fgv.Ide.Corporativohotsite.MultiTenancy;

namespace Fgv.Ide.Corporativohotsite.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options, 
            SignInManager signInManager,
            ISystemClock systemClock) 
            : base(options, signInManager, systemClock)
        {
        }
    }
}