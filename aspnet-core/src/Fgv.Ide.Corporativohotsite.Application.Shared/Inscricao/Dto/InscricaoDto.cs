using System;
using System.Collections.Generic;
using System.Text;

namespace Fgv.Ide.Corporativohotsite.Dto
{
    public class InscricaoDto
    {
        public string NomeInscrito { get; set; }
        public string Cpf { get; set; }
        public string Passaporte { get; set; }
        public long IdSituacaoCandidato { get; set; }
        public long IdOferta { get; set; }
        public long IdOpcaoOferta { get; set; }
        public string NovaSituacaoCandidato { get; set; }
        public long NovoIdSituacaoCandidato { get; set; }
    }
}
