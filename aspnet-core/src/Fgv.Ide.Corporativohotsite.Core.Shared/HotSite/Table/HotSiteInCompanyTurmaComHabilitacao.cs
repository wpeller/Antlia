using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fgv.Ide.Corporativohotsite.HotSite.Table
{
    [Table("HotSiteInCompanyTurmaComHabilitacaoDto")]
    public class HotSiteInCompanyTurmaComHabilitacao : Entity<long>
    {
        public long IdHotSiteIncompany { get; set; }
        public string CodigoTurma { get; set; }
        public string NomeCurso { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public string CPF { get; set; }

        public string Passaporte { get; set; }

        public string NomeInscrito { get; set; }

        public long IdInscricao { get; set; }

        public string GetTurmaCurso
        {
            get {
                return $"{CodigoTurma } - {NomeCurso } - {DataInicio.ToString("dd/MM/yyyy")} à {DataFim.ToString("dd/MM/yyyy")}";

            }

        }
    }
}

 