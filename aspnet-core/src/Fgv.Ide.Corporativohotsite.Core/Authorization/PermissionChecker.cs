using Abp.Authorization;
using Fgv.Ide.Corporativohotsite.Authorization.Roles;
using Fgv.Ide.Corporativohotsite.Authorization.Users;

namespace Fgv.Ide.Corporativohotsite.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
