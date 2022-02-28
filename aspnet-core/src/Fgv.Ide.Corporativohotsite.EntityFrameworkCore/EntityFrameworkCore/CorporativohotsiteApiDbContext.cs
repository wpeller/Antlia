using Abp.EntityFrameworkCore;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using Fgv.Ide.Corporativohotsite.HotSite.View;
using Fgv.Ide.Corporativohotsite.ObjetoValor.Table;
using Fgv.Ide.Corporativohotsite.Table;
using Microsoft.EntityFrameworkCore;
using MovimentosManuais.ApplicationCore;
using MovimentosManuais.ApplicationCore.Entity;

namespace Fgv.Ide.Corporativohotsite.EntityFrameworkCore
{
    public class CorporativohotsiteApiDbContext : AbpDbContext
    {
        public CorporativohotsiteApiDbContext(DbContextOptions<CorporativohotsiteApiDbContext> options) : base(options)
        {
        }

        public DbSet<OpcaoOferta> OpcaoOferta { get; set; }
        public DbSet<HotSiteHabilitacaoPrevia> VwHotsiteHabilitacaoPreviaInscricao { get; set; }
        public DbSet<HotSiteInCompanyTurma> HotSiteInCompanyTurma { get; set; }
        public DbSet<HotSiteInCompany> HotSiteInCompany { get; set; }
        public DbSet<HotSiteInCompanyConfiguracao> HotSiteInCompanyConfiguracao { get; set; }
        public DbSet<HotSiteInCompanyConfiguracaoPublicado> HotSiteInCompanyConfiguracaoPublicado { get; set; }
        public DbSet<HotSiteInCompanyImagemCarrossel> HotSiteInCompanyImagemCarrossel { get; set; }
        public DbSet<HotSiteInCompanyImagemCarrosselPublicado> HotSiteInCompanyImagemCarrosselPublicado { get; set; }
        public DbSet<HotSiteInCompanyMenu> HotSiteInCompanyMenu { get; set; }
        public DbSet<HotSiteInCompanyMenuPublicado> HotSiteInCompanyMenusPublicado { get; set; }
        public DbSet<HotSiteInCompanyMenuDocumento> HotSiteInCompanyMenuDocumento { get; set; }
        public DbSet<HotSiteInCompanyMenuDocumentoPublicado> HotSiteInCompanyMenuDocumentoPublicado { get; set; }
        public virtual DbSet<InfoGerenciarInscritosHotSiteIncompany> InfoGerenciarInscritosHotSiteIncompany { get; set; }

        public DbSet<HotSiteIncompanyLogin> HotSiteIncompanyLogin { get; set; }

        public DbSet<Inscricao> Inscricao { get; set; }
        public DbSet<SituacaoCandidato> SituacaoCandidato { get; set; }
        public virtual DbSet<ObjValor> ObjetoValor { get; set; }
        public virtual DbSet<HotSiteInCompanyTurmaComHabilitacao> HotSiteInCompanyTurmaComHabilitacao { get; set; }


        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<Produto_Cosif> Produto_Cosif { get; set; }
        public virtual DbSet<Movimento_Manual> Movimento_Manual { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OpcaoOferta>();
            modelBuilder.Entity<HotSiteHabilitacaoPrevia>();
            modelBuilder.Entity<HotSiteInCompanyTurma>();
            modelBuilder.Entity<HotSiteInCompany>();
            modelBuilder.Entity<HotSiteInCompanyConfiguracao>();
            modelBuilder.Entity<HotSiteInCompanyConfiguracaoPublicado>();
            modelBuilder.Entity<HotSiteInCompanyImagemCarrossel>();
            modelBuilder.Entity<HotSiteInCompanyImagemCarrosselPublicado>();
            modelBuilder.Entity<HotSiteInCompanyMenu>().HasMany(x => x.SubMenus).WithOne().HasForeignKey(x => x.IdMenuPai);
            modelBuilder.Entity<HotSiteInCompanyMenuPublicado>().HasMany(x => x.SubMenus).WithOne().HasForeignKey(x => x.IdMenuPai);
            modelBuilder.Entity<HotSiteInCompanyMenuDocumento>();
            modelBuilder.Entity<HotSiteInCompanyMenuDocumentoPublicado>();
            modelBuilder.Entity<InfoGerenciarInscritosHotSiteIncompany>().Ignore(p => p.Id);
            modelBuilder.Entity<InfoGerenciarInscritosHotSiteIncompany>().HasKey(p => new
            {
                p.Turma

            });
            modelBuilder.Entity<HotSiteIncompanyLogin>();
            modelBuilder.Entity<Inscricao>().Property(p => p.Id).HasColumnName("IdInscricao");
            modelBuilder.Entity<SituacaoCandidato>().Property(p => p.Id).HasColumnName("IdSituacaoCandidato");
            modelBuilder.Entity<ObjValor>().Property(p => p.Id).HasColumnName("IdObjetoValor");
            modelBuilder.Entity<HotSiteInCompanyTurma>().Property(p => p.Id).HasColumnName("Id");
            modelBuilder.Entity<HotSiteInCompanyTurmaComHabilitacao>().Property(p => p.Id).HasColumnName("Id");



            modelBuilder.Entity<Produto>().Property(p => p.Id).HasColumnName("COD_PRODUTO");


            modelBuilder.Entity<Produto_Cosif>().HasKey(ba => new { ba.COD_COSIF, ba.COD_PRODUTO });

            modelBuilder.Entity<Movimento_Manual>().HasKey(ba => new { ba.DAT_ANO, ba.DAT_MES, ba.COD_COSIF   });

            base.OnModelCreating(modelBuilder);
        }
    }
}
