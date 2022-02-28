using Fgv.Ide.Corporativohotsite.Dto;

namespace Fgv.Ide.Corporativohotsite.Organizations.Dto
{
    public class FindOrganizationUnitUsersInput : PagedAndFilteredInputDto
    {
        public long OrganizationUnitId { get; set; }
    }
}
