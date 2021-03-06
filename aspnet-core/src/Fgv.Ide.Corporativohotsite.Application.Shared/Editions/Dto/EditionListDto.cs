using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;

namespace Fgv.Ide.Corporativohotsite.Editions.Dto
{
    public class EditionListDto : EntityDto, IHasCreationTime
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public DateTime CreationTime { get; set; }
    }
}