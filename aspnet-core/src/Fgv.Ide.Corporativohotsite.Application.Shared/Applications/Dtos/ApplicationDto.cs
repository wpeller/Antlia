
using System;
using Abp.Application.Services.Dto;

namespace Fgv.Ide.Corporativohotsite.Applications.Dtos
{
    public class ApplicationDto : EntityDto<Guid>
    {
		public string Name { get; set; }

		public string UrlPath { get; set; }

		public int SecondsToExpire { get; set; }



    }
}