using System;
using System.Collections.Generic;
using System.Text;
using Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis.PapelServico.Dto;

namespace Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis.DashboardServico.Dto
{
	public class AvisoDto
	{
		public virtual long Id { get; set; }
		public virtual string Titulo { get; set; }
		public virtual string Texto { get; set; }
		public virtual DateTime InicioVigencia { get; set; }
		public virtual DateTime FimVigencia { get; set; }
		public virtual List<PapelDto> Papeis { get; set; }
	}
}
