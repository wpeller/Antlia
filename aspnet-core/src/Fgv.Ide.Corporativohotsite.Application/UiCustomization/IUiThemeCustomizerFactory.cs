using System.Threading.Tasks;
using Abp.Dependency;

namespace Fgv.Ide.Corporativohotsite.UiCustomization
{
    public interface IUiThemeCustomizerFactory : ISingletonDependency
    {
        Task<IUiCustomizer> GetCurrentUiCustomizer();

        IUiCustomizer GetUiCustomizer(string theme);
    }
}