using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Fgv.Ide.Corporativohotsite.Configuration.Dto;

namespace Fgv.Ide.Corporativohotsite.Configuration
{
    public interface IUiCustomizationSettingsAppService : IApplicationService
    {
        Task<List<ThemeSettingsDto>> GetUiManagementSettings();

        Task UpdateUiManagementSettings(ThemeSettingsDto settings);

        Task UpdateDefaultUiManagementSettings(ThemeSettingsDto settings);

        Task UseSystemDefaultSettings();
    }
}
