using Fgv.Ide.Corporativohotsite.Configuration.Dto;

namespace Fgv.Ide.Corporativohotsite.UiCustomization.Dto
{
    public class UiCustomizationSettingsDto
    {
        public ThemeSettingsDto BaseSettings { get; set; }

        public bool IsLeftMenuUsed { get; set; }

        public bool IsTopMenuUsed { get; set; }

        public bool IsTabMenuUsed { get; set; }
    }
}
