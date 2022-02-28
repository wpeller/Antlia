using System;
using System.Collections.Generic;
using System.Text;

namespace Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis.DashboardServico.Dto
{
	public class CategoriaDocumentoSigaDto
	{
		public long? Id { get; set; }
		public string Nome { get; set; }
		public int? Nivel { get; set; }
		public CategoriaDocumentoSigaPaiDto Pai { get; set; }
		public List<CategoriaDocumentoSigaFilhoDto> Filhos { get; set; }
	}
}
