using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis
{
	public class HttpClientApiMethod : HttpMethod
	{
		public HttpClientApiMethod(string method) : base(method)
		{
		}
	}
}
