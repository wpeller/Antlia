using Microsoft.Extensions.Configuration;

namespace Fgv.Ide.Corporativohotsite.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
