using System.Threading.Tasks;
using Abp.Application.Services;
using Fgv.Ide.Corporativohotsite.Configuration.Host.Dto;

namespace Fgv.Ide.Corporativohotsite.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
