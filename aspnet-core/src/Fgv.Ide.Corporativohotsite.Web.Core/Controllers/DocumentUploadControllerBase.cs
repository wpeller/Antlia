using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abp.IO.Extensions;
using Fgv.Ide.Corporativohotsite.Dto;
using Fgv.Ide.Corporativohotsite.Storage;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Fgv.Ide.Corporativohotsite.Web.Controllers
{
	public class DocumentUploadControllerBase : CorporativohotsiteControllerBase
	{
		private readonly ITempFileCacheManager _tempFileCacheManager;
		private const int MaxProfilePictureSize = 5242880; //5MB

		public DocumentUploadControllerBase(ITempFileCacheManager tempFileCacheManager)
		{
			_tempFileCacheManager = tempFileCacheManager;
		}

		public DocumentoDto Upload(FileDto file)
		{
			var files = Request.Form.Files;
			if (files?.Count > 0)
			{
				var fileUpload = file;
				byte[] fileBytes;
				var fileSend = files.First();
				using (var stream = fileSend.OpenReadStream())
				{
					fileBytes = stream.GetAllBytes();
				}
				_tempFileCacheManager.SetDocumentFile(fileUpload.FileToken, fileBytes);
				return new DocumentoDto()
				{
					IdArquivo = fileUpload.FileToken,
					Extensao = fileUpload.FileType,
					NomeArquivo = fileUpload.FileName,
					Tamanho = fileBytes.Length.ToString()
				};
			}

			return null;
		}
	}
}
