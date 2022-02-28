using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Fgv.Ide.Corporativohotsite.Authorization.Permissions.Dto;

namespace Fgv.Ide.Corporativohotsite.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
