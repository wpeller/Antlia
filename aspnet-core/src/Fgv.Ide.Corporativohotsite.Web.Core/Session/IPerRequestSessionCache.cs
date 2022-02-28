using System.Threading.Tasks;
using Fgv.Ide.Corporativohotsite.Sessions.Dto;

namespace Fgv.Ide.Corporativohotsite.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
