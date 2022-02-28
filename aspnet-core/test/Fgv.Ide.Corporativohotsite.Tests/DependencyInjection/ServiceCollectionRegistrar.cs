using Abp.Dependency;
using Castle.MicroKernel.Registration;
using Castle.Windsor.MsDependencyInjection;
using Fgv.Ide.Corporativohotsite.Configuration;
using Fgv.Ide.Corporativohotsite.EntityFrameworkCore;
using Fgv.Ide.Corporativohotsite.Identity;
using Fgv.Ide.Corporativohotsite.Web;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fgv.Ide.Corporativohotsite.Tests.DependencyInjection
{
    public static class ServiceCollectionRegistrar
    {
        public static void Register(IIocManager iocManager)
        {
            RegisterIdentity(iocManager);

            CreateContextInMemory<CorporativohotsiteDbContext>(iocManager);
            CreateContextInMemory<CorporativohotsiteApiDbContext>(iocManager);
        }

        private static void CreateContextInMemory<T>(IIocManager iocManager) where T : DbContext
        {
            var builder = new DbContextOptionsBuilder<T>();

            var inMemorySqlite = new SqliteConnection("Data Source=:memory:");
            builder.UseSqlite(inMemorySqlite);

            iocManager.IocContainer.Register(
                Component
                    .For<DbContextOptions<T>>()
                    .Instance(builder.Options)
                    .LifestyleSingleton()
            );

            inMemorySqlite.Open();

            var _context = (DbContext)System.Activator.CreateInstance(typeof(T), builder.Options);
            _context.Database.EnsureCreated();
        }

        private static void CreateContextSQL<T>(IIocManager iocManager) where T : CorporativohotsiteApiDbContext
        {

            var builder = new DbContextOptionsBuilder<T>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder(), addUserSecrets: true);
            var connectionString = configuration.GetConnectionString(CorporativohotsiteConsts.ConnectionStringNameIWI);

            builder.UseSqlServer(connectionString);

            iocManager.IocContainer.Register(
                Component
                    .For<DbContextOptions<T>>()
                    .Instance(builder.Options)
                    .LifestyleSingleton()
            );

            var _context = (DbContext)System.Activator.CreateInstance(typeof(T), builder.Options);
            _context.Database.EnsureCreated();
        }

        private static void RegisterIdentity(IIocManager iocManager)
        {
            var services = new ServiceCollection();
            IdentityRegistrar.Register(services);
            WindsorRegistrationHelper.CreateServiceProvider(iocManager.IocContainer, services);
        }
    }
}
