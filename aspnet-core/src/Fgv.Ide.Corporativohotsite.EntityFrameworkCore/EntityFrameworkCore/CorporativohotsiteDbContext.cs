using System.Linq;
using Fgv.Ide.Corporativohotsite.Applications;
using Abp.IdentityServer4;
using Abp.Zero.EntityFrameworkCore;
using Fgv.Ide.Corporativohotsite.Authorization.Distributed;
using Microsoft.EntityFrameworkCore;
using Fgv.Ide.Corporativohotsite.Authorization.Roles;
using Fgv.Ide.Corporativohotsite.Authorization.Users;
using Fgv.Ide.Corporativohotsite.Editions;
using Fgv.Ide.Corporativohotsite.MultiTenancy;
using Fgv.Ide.Corporativohotsite.MultiTenancy.Accounting;
using Fgv.Ide.Corporativohotsite.MultiTenancy.Payments;
using Fgv.Ide.Corporativohotsite.Navigations;
using Fgv.Ide.Corporativohotsite.Storage;
using MovimentosManuais.ApplicationCore;
using MovimentosManuais.ApplicationCore.Entity;

namespace Fgv.Ide.Corporativohotsite.EntityFrameworkCore
{
    public class CorporativohotsiteDbContext : AbpZeroDbContext<Tenant, Role, User, CorporativohotsiteDbContext>, IAbpPersistedGrantDbContext
    {
        public virtual DbSet<Application> Applications { get; set; }

        /* Define an IDbSet for each entity of the application */

        public virtual DbSet<BinaryObject> BinaryObjects { get; set; }

        public virtual DbSet<SubscribableEdition> SubscribableEditions { get; set; }

        public virtual DbSet<SubscriptionPayment> SubscriptionPayments { get; set; }

        public virtual DbSet<Invoice> Invoices { get; set; }

        public virtual DbSet<PersistedGrantEntity> PersistedGrants { get; set; }

        public virtual DbSet<DistributedAuthorization> DistributedAuthorizations { get; set; }
        public virtual DbSet<Navigation> Navigations { get; set; }



        public CorporativohotsiteDbContext(DbContextOptions<CorporativohotsiteDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ChangeAbpTablePrefix<Tenant, Role, User>("");
            modelBuilder.Entity<BinaryObject>(b =>
            {
                b.HasIndex(e => new { e.TenantId });
            });

            modelBuilder.Entity<Tenant>(b =>
            {
                b.HasIndex(e => new { e.SubscriptionEndDateUtc });
                b.HasIndex(e => new { e.CreationTime });
            });

            modelBuilder.Entity<SubscriptionPayment>(b =>
            {
                b.HasIndex(e => new { e.Status, e.CreationTime });
                b.HasIndex(e => new { e.PaymentId, e.Gateway });
            });

            modelBuilder.ConfigurePersistedGrantEntity();

        }

        //Adjust Conventions
        //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        //{
        //    //Remove PluralizingTableName
        //    if (entityType.ClrType != null)
        //        entityType.Relational().TableName = entityType.ClrType.Name;

        //    //Remove OneToManyCascadeDelete and ManyToManyCascadeDelete
        //    //entityType.GetForeignKeys().Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade).ToList().ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);

        //    //Remove Unicode
        //    entityType.GetProperties().Where(p => p.ClrType == typeof(string)).ToList().ForEach(p => p.IsUnicode(false));

        //    //Set MaxLength
        //    entityType.GetProperties().Where(p => p.ClrType == typeof(string) && !p.GetMaxLength().HasValue).ToList().ForEach(p => p.SetMaxLength(1000));
        //}
    }
}
