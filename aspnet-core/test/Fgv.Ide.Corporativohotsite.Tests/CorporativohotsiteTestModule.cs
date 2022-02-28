using System;
using System.IO;
using Abp;
using Abp.AspNetZeroCore;
using Abp.AutoMapper;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Modules;
using Abp.Net.Mail;
using Abp.Organizations;
using Abp.TestBase;
using Abp.Zero.Configuration;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;
using Fgv.Ide.Corporativohotsite.Authorization.Roles;
using Fgv.Ide.Corporativohotsite.Authorization.Users;
using Fgv.Ide.Corporativohotsite.Configuration;
using Fgv.Ide.Corporativohotsite.EntityFrameworkCore;
using Fgv.Ide.Corporativohotsite.Migrations.Seed;
using Fgv.Ide.Corporativohotsite.MultiTenancy;
using Fgv.Ide.Corporativohotsite.Security.Recaptcha;
using Fgv.Ide.Corporativohotsite.Tests.Configuration;
using Fgv.Ide.Corporativohotsite.Tests.DependencyInjection;
using Fgv.Ide.Corporativohotsite.Tests.UiCustomization;
using Fgv.Ide.Corporativohotsite.Tests.Url;
using Fgv.Ide.Corporativohotsite.Tests.Web;
using Fgv.Ide.Corporativohotsite.UiCustomization;
using Fgv.Ide.Corporativohotsite.Url;
using NSubstitute;
using Fgv.Ide.Corporativohotsite.HotSite;

namespace Fgv.Ide.Corporativohotsite.Tests
{
    [DependsOn(
        typeof(CorporativohotsiteApplicationModule),
        typeof(CorporativohotsiteEntityFrameworkCoreModule),
        typeof(AbpTestBaseModule))]
    public class CorporativohotsiteTestModule : AbpModule
    {
        public CorporativohotsiteTestModule(CorporativohotsiteEntityFrameworkCoreModule abpZeroTemplateEntityFrameworkCoreModule)
        {
            abpZeroTemplateEntityFrameworkCoreModule.SkipDbContextRegistration = true;
            abpZeroTemplateEntityFrameworkCoreModule.SkipDbSeed = true;
        }

        public override void PreInitialize()
        {
            IocManager.IocContainer.Kernel.AddHandlerSelector(new CastleSelectorHandler());

            var configuration = GetConfiguration();

            Configuration.UnitOfWork.Timeout = TimeSpan.FromMinutes(30);
            Configuration.UnitOfWork.IsTransactional = false;

            //Disable static mapper usage since it breaks unit tests (see https://github.com/aspnetboilerplate/aspnetboilerplate/issues/2052)
            Configuration.Modules.AbpAutoMapper().UseStaticMapper = false;

            //Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            

            IocManager.Register<IAppUrlService, FakeAppUrlService>();
            IocManager.Register<IWebUrlService, FakeWebUrlService>();
            IocManager.Register<IRecaptchaValidator, FakeRecaptchaValidator>();
            IocManager.Register<IHotSiteInCompanyAppService, HotSiteInCompanyAppService>();

            Configuration.ReplaceService<IAppConfigurationAccessor, TestAppConfigurationAccessor>();
            Configuration.ReplaceService<IEmailSender, NullEmailSender>(DependencyLifeStyle.Transient);

            Configuration.ReplaceService<IUiThemeCustomizerFactory, NullUiThemeCustomizerFactory>();

            Configuration.Modules.AspNetZero().LicenseCode = configuration["AbpZeroLicenseCode"];

            //Uncomment below line to write change logs for the entities below:
            Configuration.EntityHistory.IsEnabled = true;
            Configuration.EntityHistory.Selectors.Add("CorporativohotsiteEntities", typeof(User), typeof(Tenant));
        }

        public override void Initialize()
        {
            ServiceCollectionRegistrar.Register(IocManager);
            SeedHelper.SeedHostDb(IocManager);
            //RegisterFakeService<AbpZeroDbMigrator>();
        }

        private void RegisterFakeService<TService>()
            where TService : class
        {
            IocManager.IocContainer.Register(
                Component.For<TService>()
                    .UsingFactoryMethod(() => Substitute.For<TService>())
                    .LifestyleSingleton()
            );
        }

        private static IConfigurationRoot GetConfiguration()
        {
            return AppConfigurations.Get(Directory.GetCurrentDirectory(), addUserSecrets: true);
        }
    }
}
