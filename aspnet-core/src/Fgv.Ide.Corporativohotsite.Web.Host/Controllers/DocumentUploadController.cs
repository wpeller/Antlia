using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fgv.Ide.Corporativohotsite.Storage;

namespace Fgv.Ide.Corporativohotsite.Web.Controllers
{
	public class DocumentUploadController : DocumentUploadControllerBase
	{
		public DocumentUploadController(ITempFileCacheManager tempFileCacheManager) : base(tempFileCacheManager)
		{
		}
	}
}
