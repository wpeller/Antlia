using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fgv.Ide.Corporativohotsite.HotSite.Table
{
    public class HotSiteInCompanyConfiguracaoBase : Entity<long>
    {
        public string CorFundo { get; set; }
        public string CorTitulo { get; set; }
        public string CorBarraMenu { get; set; }
        public string LogoFGV { get; set; }
        public string LogoEmpresa1 { get; set; }
        public string LogoEmpresa2 { get; set; }
        public long IdHotSiteIncompany { get; set; }
    }

    [Table("HotSiteInCompanyConfiguracao")]
    public class HotSiteInCompanyConfiguracao : HotSiteInCompanyConfiguracaoBase
    {
    }

    [Table("HotSiteInCompanyConfiguracaoPublicado")]
    public class HotSiteInCompanyConfiguracaoPublicado : HotSiteInCompanyConfiguracaoBase
    {
    }
}
