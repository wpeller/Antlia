using System.Threading.Tasks;
using Abp.Application.Services;

namespace Fgv.Ide.Corporativohotsite.MultiTenancy
{
    public interface ISubscriptionAppService : IApplicationService
    {
        Task UpgradeTenantToEquivalentEdition(int upgradeEditionId);
    }
}
