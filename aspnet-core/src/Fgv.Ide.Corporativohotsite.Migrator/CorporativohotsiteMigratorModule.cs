using Abp.AspNetZeroCore;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;
using Fgv.Ide.Corporativohotsite.Configuration;
using Fgv.Ide.Corporativohotsite.EntityFrameworkCore;
using Fgv.Ide.Corporativohotsite.Migrator.DependencyInjection;

namespace Fgv.Ide.Corporativohotsite.Migrator
{
    [DependsOn(typeof(CorporativohotsiteEntityFrameworkCoreModule))]
    public class CorporativohotsiteMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public CorporativohotsiteMigratorModule(CorporativohotsiteEntityFrameworkCoreModule abpZeroTemplateEntityFrameworkCoreModule)
        {
            abpZeroTemplateEntityFrameworkCoreModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(CorporativohotsiteMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            IocManager.IocContainer.Kernel.AddHandlerSelector(new CastleSelectorHandler());

            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                CorporativohotsiteConsts.ConnectionStringName
                );
            Configuration.Modules.AspNetZero().LicenseCode = _appConfiguration["AbpZeroLicenseCode"];

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(typeof(IEventBus), () =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CorporativohotsiteMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}