using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fgv.Ide.Corporativohotsite.HotSite.Table
{
    public class HotSiteInCompanyMenuBase : Entity<long>
    {
        public string Descricao { get; set; }
        public int Ordem { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public bool Ativo { get; set; }
        public bool? Restrito { get; set; }
        public long? IdMenuPai { get; set; }
        public long IdHotSiteIncompany { get; set; }
        public string Rota { get; set; }
    }

    [Table("HotSiteInCompanyMenu")]
    public class HotSiteInCompanyMenu : HotSiteInCompanyMenuBase
    {
        //public HotSiteInCompanyMenu MenuPai { get; set; }

        public List<HotSiteInCompanyMenu> SubMenus { get; set; }
    }

    [Table("HotSiteInCompanyMenuPublicado")]
    public class HotSiteInCompanyMenuPublicado : HotSiteInCompanyMenuBase
    {
        //public HotSiteInCompanyMenuPublicado MenuPai { get; set; }

        public List<HotSiteInCompanyMenuPublicado> SubMenus { get; set; }
    }
}
