using System;
using System.Collections.Generic;
using System.Text;

namespace Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis.MenuServico.Dto
{
	public class ObterItemMenuInput
	{
		public long? Id { get; set; }
		public string Titulo { get; set; }
		public string Nome { get; set; }
		public string Rota { get; set; }
	}
}
