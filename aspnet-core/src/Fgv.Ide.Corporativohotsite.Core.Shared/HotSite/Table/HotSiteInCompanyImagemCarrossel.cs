using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fgv.Ide.Corporativohotsite.HotSite.Table
{
    public class HotSiteInCompanyImagemCarrosselBase : Entity<long>
    {
        public string Nome { get; set; }
        public string Extensao { get; set; }
        public string Token { get; set; }
        public long IdHotSiteIncompany { get; set; }
    }

    [Table("HotSiteInCompanyImagemCarrossel")]
    public class HotSiteInCompanyImagemCarrossel : HotSiteInCompanyImagemCarrosselBase
    {
    }

    [Table("HotSiteInCompanyImagemCarrosselPublicado")]
    public class HotSiteInCompanyImagemCarrosselPublicado : HotSiteInCompanyImagemCarrosselBase
    {
    }
}
