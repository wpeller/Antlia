using System;
using System.Collections.Generic;
using System.Text;

namespace Fgv.Ide.Corporativohotsite.HotSite.Dto
{
   public class HotSiteTurmaDto
    {
        public long IdHotSiteIncompany { get; set; }
        public string CodigoTurma { get; set; }
        public string NomeCurso { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public string GetTurmaCurso
        {
            get
            {
                return $"{CodigoTurma } - {NomeCurso } - {DataInicio.ToString("dd/MM/yyyy")} à {DataFim.ToString("dd/MM/yyyy")}";

            }

        }
    }
}
