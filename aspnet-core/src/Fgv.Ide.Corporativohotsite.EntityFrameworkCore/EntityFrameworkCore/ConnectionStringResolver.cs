using Abp.Configuration.Startup;
using Abp.Domain.Uow;
using Fgv.Ide.Corporativohotsite.Configuration;
using Microsoft.Extensions.Configuration;
using System;

namespace Fgv.Ide.Corporativohotsite.EntityFrameworkCore
{
    public class ConnectionStringResolver : DefaultConnectionStringResolver
    {
        private readonly IAppConfigurationAccessor _configurationAcessor;
        public ConnectionStringResolver(IAbpStartupConfiguration configuration, IAppConfigurationAccessor configurationAcessor) : base(configuration)
        {
            _configurationAcessor = configurationAcessor;
        }

        public override string GetNameOrConnectionString(ConnectionStringResolveArgs args)
        {
            if (args["DbContextConcreteType"] as Type == typeof(CorporativohotsiteApiDbContext))
            {
                return _configurationAcessor.Configuration.GetConnectionString(CorporativohotsiteConsts.ConnectionStringNameIWI);
            }
            return base.GetNameOrConnectionString(args);
        }
    }
}
