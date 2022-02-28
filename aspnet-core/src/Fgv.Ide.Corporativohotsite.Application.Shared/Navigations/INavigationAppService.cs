using System.Threading.Tasks;
using Abp.Application.Services;

namespace Fgv.Ide.Corporativohotsite.Navigations
{
    public interface INavigationAppService : IApplicationService
    {
        Task<NavigationDto> SendAndSynchronize(NavigationDto model);
    }
}