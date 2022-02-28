using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fgv.Ide.Corporativohotsite.HotSite.Table
{
    public class HotSiteInCompanyMenuDocumentoBase : Entity<long>
    {
        public string Nome { get; set; }
        public string Extensao { get; set; }
        public string Token { get; set; }
        public long? IdMenu { get; set; }
    }

    [Table("HotSiteInCompanyMenuDocumento")]
    public class HotSiteInCompanyMenuDocumento : HotSiteInCompanyMenuDocumentoBase
    {
    }

    [Table("HotSiteInCompanyMenuPublicadoDocumento")]
    public class HotSiteInCompanyMenuDocumentoPublicado : HotSiteInCompanyMenuDocumentoBase
    {
    }
}
