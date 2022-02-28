using System;
using System.Transactions;
using Abp.Data;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore;
using Abp.MultiTenancy;
using Abp.Zero.EntityFrameworkCore;
using Castle.Core.Internal;
using Fgv.Ide.Corporativohotsite.Configuration;
using Fgv.Ide.Corporativohotsite.Migrations.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fgv.Ide.Corporativohotsite.EntityFrameworkCore
{
    public class AbpZeroDbMigrator : AbpZeroDbMigrator<CorporativohotsiteDbContext>
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IDbPerTenantConnectionStringResolver _connectionStringResolver;
        private readonly IDbContextResolver _dbContextResolver;
        private readonly IAppConfigurationAccessor _appConfigurationAccessor;

        public AbpZeroDbMigrator(
            IUnitOfWorkManager unitOfWorkManager,
            IDbPerTenantConnectionStringResolver connectionStringResolver,
            IDbContextResolver dbContextResolver, IAppConfigurationAccessor appConfigurationAccessor) :
            base(
                unitOfWorkManager,
                connectionStringResolver,
                dbContextResolver)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _connectionStringResolver = connectionStringResolver;
            _dbContextResolver = dbContextResolver;
            _appConfigurationAccessor = appConfigurationAccessor;
        }

        public void CreateOrMigrate()
        {
            CreateOrMigrate(null, SeedHelper.SeedHostDb);
        }

        protected override void CreateOrMigrate(AbpTenantBase tenant, Action<CorporativohotsiteDbContext> seedAction)
        {
            var args = new DbPerTenantConnectionStringResolveArgs(
                tenant == null ? (int?)null : (int?)tenant.Id,
                tenant == null ? MultiTenancySides.Host : MultiTenancySides.Tenant
            );

            args["DbContextType"] = typeof(CorporativohotsiteDbContext);
            args["DbContextConcreteType"] = typeof(CorporativohotsiteDbContext);

            var nameOrConnectionString = ConnectionStringHelper.GetConnectionString(
                _connectionStringResolver.GetNameOrConnectionString(args)
            );

            using (var uow = _unitOfWorkManager.Begin(TransactionScopeOption.Suppress))
            {
                using (var dbContext = _dbContextResolver.Resolve<CorporativohotsiteDbContext>(nameOrConnectionString, null))
                {
                    var targetMigration = _appConfigurationAccessor.Configuration["EntityFramework.Migrations.TargetMigration"];
                    if (!string.IsNullOrEmpty(targetMigration) || dbContext.Database.GetPendingMigrations().Any())
                    {
                        dbContext.GetService<IMigrator>().Migrate(string.IsNullOrEmpty(targetMigration)?null: targetMigration);
                        seedAction?.Invoke(dbContext);
                        _unitOfWorkManager.Current.SaveChanges();
                    }
                    uow.Complete();
                }
            }
        }
    }
}
