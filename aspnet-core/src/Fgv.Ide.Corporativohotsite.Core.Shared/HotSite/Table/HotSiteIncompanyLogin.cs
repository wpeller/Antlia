using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Fgv.Ide.Corporativohotsite.HotSite.Table
{
    [Table("HotSiteInCompanyLogin")]
    public class HotSiteIncompanyLogin : Entity<long>
    {

        [ForeignKey("HotSiteInCompany")]
        public long IdHotSiteIncompany { get; set; }
        public HotSiteInCompany HotSiteInCompany { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Enviado { get; set; }
        public DateTime? EnviadoEm { get; set; }
        public string EnviadoPor { get; set; }
        public bool Excluido { get; set; }
        public DateTime? ExcluidoEm { get; set; }
        public string ExcluidoPor { get; set; }


    }
}
