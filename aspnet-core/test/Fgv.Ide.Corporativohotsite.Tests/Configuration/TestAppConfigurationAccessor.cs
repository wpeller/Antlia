using Abp.Dependency;
using Abp.Reflection.Extensions;
using Microsoft.Extensions.Configuration;
using Fgv.Ide.Corporativohotsite.Configuration;

namespace Fgv.Ide.Corporativohotsite.Tests.Configuration
{
    public class TestAppConfigurationAccessor : IAppConfigurationAccessor, ISingletonDependency
    {
        public IConfigurationRoot Configuration { get; }

        public TestAppConfigurationAccessor()
        {
            Configuration = AppConfigurations.Get(
                typeof(CorporativohotsiteTestModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }
    }
}
