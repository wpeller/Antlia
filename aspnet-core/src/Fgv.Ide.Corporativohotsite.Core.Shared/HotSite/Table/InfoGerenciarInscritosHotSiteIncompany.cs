using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Fgv.Ide.Corporativohotsite.HotSite.View
{
    [Table("FGV_InfoGerenciarInscritosHotSiteIncompany")]
    public class InfoGerenciarInscritosHotSiteIncompany : Entity
    {
        [Key, Column(Order = 0)]
        public string TipoTurma { get; set; }
        public string Turma { get; set; }
        public string NomeInscrito { get; set; }
        public string CPF { get; set; }
        public string Passaporte { get; set; }
        public long IdSituacaoCandidato { get; set; }
        public string SituacaoCandidato { get; set; }
        public long IdProjetoIncompany { get; set; }
        public string NomeProjeto { get; set; }
        public long IdHotSite { get; set; }
        public string NomeHotSite { get; set; }
        public bool HabilitaPrevia { get; set; }
        public long IdOFerta { get; set; }
        public long IdOpcaoOferta { get; set; }

    }
}