using System;
using System.Collections.Generic;
using System.Text;

namespace Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis
{
	public class HttpClientApiApplication
	{
		public string Name { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public object Connector { get; set; }
		public DateTime DataExpiracaoToken { get; set; }
	}
}
