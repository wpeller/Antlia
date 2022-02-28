using System.Collections.Generic;
using Fgv.Ide.Corporativohotsite.Authorization.Permissions.Dto;

namespace Fgv.Ide.Corporativohotsite.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}