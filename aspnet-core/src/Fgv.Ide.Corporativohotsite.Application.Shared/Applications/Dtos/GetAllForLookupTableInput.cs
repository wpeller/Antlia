using Abp.Application.Services.Dto;

namespace Fgv.Ide.Corporativohotsite.Applications.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
		public string Filter { get; set; }
    }
}