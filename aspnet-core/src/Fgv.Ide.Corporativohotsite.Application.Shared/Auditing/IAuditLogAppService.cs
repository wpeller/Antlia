using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Fgv.Ide.Corporativohotsite.Auditing.Dto;
using Fgv.Ide.Corporativohotsite.Dto;

namespace Fgv.Ide.Corporativohotsite.Auditing
{
    public interface IAuditLogAppService : IApplicationService
    {
        Task<PagedResultDto<AuditLogListDto>> GetAuditLogs(GetAuditLogsInput input);

        Task<FileDto> GetAuditLogsToExcel(GetAuditLogsInput input);

        Task<PagedResultDto<EntityChangeListDto>> GetEntityChanges(GetEntityChangeInput input);

        Task<PagedResultDto<EntityChangeListDto>> GetEntityTypeChanges(GetEntityTypeChangeInput input);

        Task<FileDto> GetEntityChangesToExcel(GetEntityChangeInput input);

        Task<List<EntityPropertyChangeDto>> GetEntityPropertyChanges(long entityChangeId);

        List<NameValueDto> GetEntityHistoryObjectTypes();
    }
}