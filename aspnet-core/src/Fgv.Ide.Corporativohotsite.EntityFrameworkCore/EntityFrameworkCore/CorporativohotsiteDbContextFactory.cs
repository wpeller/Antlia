using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Fgv.Ide.Corporativohotsite.Configuration;
using Fgv.Ide.Corporativohotsite.Web;

namespace Fgv.Ide.Corporativohotsite.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class CorporativohotsiteDbContextFactory : IDesignTimeDbContextFactory<CorporativohotsiteDbContext>
    {
        public CorporativohotsiteDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CorporativohotsiteDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder(), addUserSecrets: true);

            CorporativohotsiteDbContextConfigurer.Configure(builder, configuration.GetConnectionString(CorporativohotsiteConsts.ConnectionStringName));

            return new CorporativohotsiteDbContext(builder.Options);
        }
    }
}