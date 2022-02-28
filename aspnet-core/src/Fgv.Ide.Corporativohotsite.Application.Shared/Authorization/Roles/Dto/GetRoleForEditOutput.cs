using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Fgv.Ide.Corporativohotsite.Authorization.Permissions.Dto;

namespace Fgv.Ide.Corporativohotsite.Authorization.Roles.Dto
{
    public class GetRoleForEditOutput
    {
        public RoleEditDto Role { get; set; }

        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}