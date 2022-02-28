using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fgv.Ide.Corporativohotsite.HotSite.Table
{
    [Table("HotSiteInCompany")]
    public class HotSiteInCompany : Entity<long>
    {
        public long ProjetoId { get; set; }
        public string NomeHotSite { get; set; }
        public bool Regulamento { get; set; }
        public bool HabilitarPrevia { get; set; }
        public bool? Publicado { get; set; }
        public DateTime? DesativadoEm { get; set; }
        public string DesativadoPor { get; set; }
        public bool? Excluido { get; set; }
        public string ExcluidoPor { get; set; }
        public DateTime? ExcluidoEm { get; set; }
        public bool? CopiaSuja { get; set; }
        public bool? PendentePublicacao { get; set; }
    }
}
