using System.Threading.Tasks;
using Abp;
using Abp.Dependency;
using Fgv.Ide.Corporativohotsite.Configuration.Dto;
using Fgv.Ide.Corporativohotsite.UiCustomization.Dto;

namespace Fgv.Ide.Corporativohotsite.UiCustomization
{
    public interface IUiCustomizer : ISingletonDependency
    {
        Task<UiCustomizationSettingsDto> GetUiSettings();

        Task UpdateUserUiManagementSettingsAsync(UserIdentifier user, ThemeSettingsDto settings);

        Task UpdateTenantUiManagementSettingsAsync(int tenantId, ThemeSettingsDto settings);

        Task UpdateApplicationUiManagementSettingsAsync(ThemeSettingsDto settings);

        Task<ThemeSettingsDto> GetHostUiManagementSettings();

        Task<ThemeSettingsDto> GetTenantUiCustomizationSettings(int tenantId);
    }
}
