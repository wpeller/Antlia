using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries;
using Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis;
using Fgv.Ide.Corporativohotsite.Authorization.Distributed;
using Fgv.Ide.Corporativohotsite.HotSite;
using Fgv.Ide.Corporativohotsite.HotSite.Interfaces;
using Fgv.Tic.WsConnectorCore;

namespace Fgv.Ide.Corporativohotsite
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(CorporativohotsiteCoreModule)
        )]
    public class CorporativohotsiteApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<DistributedAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CorporativohotsiteApplicationModule).GetAssembly());
            IocManager.Register<IdentityManager.IdentityManager>();
            IocManager.RegisterIfNot<Connector>();
            IocManager.RegisterIfNot<ConfigurationResolver>();
            IocManager.RegisterIfNot<IHttpClientApiRequest, HttpClientApiRequest>();
            IocManager.RegisterIfNot<IHotSiteInCompanyConfiguracaoManager, HotSiteInCompanyConfiguracaoManager>();
            IocManager.RegisterIfNot<IHotSiteInCompanyConfiguracaoPublicadoManager, HotSiteInCompanyConfiguracaoPublicadoManager>();
            IocManager.RegisterIfNot<IHotSiteInCompanyMenuManager, HotSiteInCompanyMenuManager>();
            IocManager.RegisterIfNot<IHotSiteInCompanyMenuPublicadoManager, HotSiteInCompanyMenuPublicadoManager>();
            IocManager.RegisterIfNot<IHotSiteInCompanyCarrosselManager, HotSiteInCompanyCarrosselManager>();
            IocManager.RegisterIfNot<IHotSiteInCompanyCarrosselPublicadoManager, HotSiteInCompanyCarrosselPublicadoManager>();
            IocManager.RegisterIfNot<IHotSiteIncompanyManager, HotSiteIncompanyManager>();
            IocManager.RegisterIfNot<IHotSiteInCompanyMenuDocumentoManager, HotSiteInCompanyMenuDocumentoManager>();
            IocManager.RegisterIfNot<IHotSiteInCompanyMenuDocumentoPublicadoManager, HotSiteInCompanyMenuDocumentoPublicadoManager>();
            IocManager.RegisterIfNot<IHotSiteInCompanyGerenciarInscritosManager, HotSiteInCompanyGerenciarInscritosManager>();
        }
    }
}