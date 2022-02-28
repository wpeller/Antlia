using System.Threading.Tasks;
using Abp.Application.Services;
using Fgv.Ide.Corporativohotsite.Sessions.Dto;

namespace Fgv.Ide.Corporativohotsite.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
