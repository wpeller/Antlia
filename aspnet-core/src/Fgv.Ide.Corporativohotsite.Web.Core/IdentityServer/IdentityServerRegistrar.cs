using Abp.IdentityServer4;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Fgv.Ide.Corporativohotsite.Authorization.Users;
using Fgv.Ide.Corporativohotsite.EntityFrameworkCore;

namespace Fgv.Ide.Corporativohotsite.Web.IdentityServer
{
    public static class IdentityServerRegistrar
    {
        public static void Register(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResources())
                .AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
                .AddInMemoryClients(IdentityServerConfig.GetClients(configuration))
                .AddAbpPersistedGrants<CorporativohotsiteDbContext>()
                .AddAbpIdentityServer<User>();
        }
    }
}
