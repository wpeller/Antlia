using Abp.Configuration.Startup;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore.Configuration;
using Abp.IdentityServer4;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using Castle.MicroKernel.Registration;
using Fgv.Ide.Corporativohotsite.EntityFrameworkCore.Repositories;
using Fgv.Ide.Corporativohotsite.Repositories;

namespace Fgv.Ide.Corporativohotsite.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpZeroCoreEntityFrameworkCoreModule),
        typeof(CorporativohotsiteCoreModule),
        typeof(AbpZeroCoreIdentityServerEntityFrameworkCoreModule)
        )]
    public class CorporativohotsiteEntityFrameworkCoreModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.ReplaceService<IConnectionStringResolver, ConnectionStringResolver>();

                Configuration.Modules.AbpEfCore().AddDbContext<CorporativohotsiteApiDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        CorporativohotsiteDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        CorporativohotsiteDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });

                Configuration.Modules.AbpEfCore().AddDbContext<CorporativohotsiteDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        CorporativohotsiteDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        CorporativohotsiteDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }

            IocManager.IocContainer.Register(Component.For(typeof(ICorporativohotsiteRepository<,>))
                .ImplementedBy(typeof(CorporativohotsiteRepository<,>)).LifestyleTransient());

            // Uncomment below line to write change logs for the entities below:
            //Configuration.EntityHistory.Selectors.Add("CorporativohotsiteEntities", EntityHistoryHelper.TrackedTypes);
            //Configuration.CustomConfigProviders.Add(new EntityHistoryConfigProvider(Configuration));
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CorporativohotsiteEntityFrameworkCoreModule).GetAssembly());
            if (!SkipDbContextRegistration)
                IocManager.Resolve<AbpZeroDbMigrator>().CreateOrMigrate();
            //var configurationAccessor = IocManager.Resolve<IAppConfigurationAccessor>();

            //using (var scope = IocManager.CreateScope())
            //{
            //    if (!SkipDbSeed && scope.Resolve<DatabaseCheckHelper>().Exist(configurationAccessor.Configuration["ConnectionStrings:Default"]))
            //    {
            //        SeedHelper.SeedHostDb(IocManager);
            //    }
            //}
        }

        public override void PostInitialize()
        {

        }
    }
}
