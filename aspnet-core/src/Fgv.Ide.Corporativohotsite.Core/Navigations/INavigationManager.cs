using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Fgv.Ide.Corporativohotsite.Navigations
{
    public interface INavigationManager : IDomainService
    {
        Task CreateOrUpdateIfNecessary(IList<Navigation> navigations);
        Task<List<Navigation>> GetAllParentsAsync();
        Task RemoveOutOfDates(IList<Navigation> navigations);
    }
}