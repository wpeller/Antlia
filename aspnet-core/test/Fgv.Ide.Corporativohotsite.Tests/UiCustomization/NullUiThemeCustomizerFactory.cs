using System.Threading.Tasks;
using Fgv.Ide.Corporativohotsite.UiCustomization;

namespace Fgv.Ide.Corporativohotsite.Tests.UiCustomization
{
    public class NullUiThemeCustomizerFactory : IUiThemeCustomizerFactory
    {
        public async Task<IUiCustomizer> GetCurrentUiCustomizer()
        {
            await Task.CompletedTask;

            return new NullThemeUiCustomizer();
        }

        public IUiCustomizer GetUiCustomizer(string theme)
        {
            return new NullThemeUiCustomizer();
        }
    }
}
