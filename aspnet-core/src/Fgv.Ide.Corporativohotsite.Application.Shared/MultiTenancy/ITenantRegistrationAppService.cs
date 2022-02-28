using System.Threading.Tasks;
using Abp.Application.Services;
using Fgv.Ide.Corporativohotsite.Editions.Dto;
using Fgv.Ide.Corporativohotsite.MultiTenancy.Dto;

namespace Fgv.Ide.Corporativohotsite.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}