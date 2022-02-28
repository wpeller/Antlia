using Abp.Application.Services;
using Fgv.Ide.Corporativohotsite.Dto;
using Fgv.Ide.Corporativohotsite.Logging.Dto;

namespace Fgv.Ide.Corporativohotsite.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
