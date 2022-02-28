using System;
using System.Collections.Generic;
using System.Text;

namespace Fgv.Ide.Corporativohotsite.HotSite.Dto
{
    public class HotSiteInscritosDto
    {
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
