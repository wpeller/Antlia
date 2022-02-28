using Abp.AspNetZeroCore;
using Abp.Dependency;

namespace Fgv.Ide.Corporativohotsite
{
    public class FgvCorporativohotsiteCustomCoreModule : AbpAspNetZeroCoreModule
    {
        public override void PreInitialize()
        {
            IocManager.RegisterIfNot<AspNetZeroConfiguration>();
        }

        public override void PostInitialize()
        {
      
        }
    }
}