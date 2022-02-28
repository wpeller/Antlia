using Fgv.Ide.Corporativohotsite.Dto;

namespace Fgv.Ide.Corporativohotsite.Common.Dto
{
    public class FindUsersInput : PagedAndFilteredInputDto
    {
        public int? TenantId { get; set; }
    }
}