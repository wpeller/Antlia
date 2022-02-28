using Abp.Dependency;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite.Interfaces
{
    public interface IHotSiteIncompanyManager : ITransientDependency
    {
        Task<HotSiteInCompany> BuscarHotSitePorId(long id);
        Task<HotSiteInCompany> BuscarHotSitePorNome(string nomeHotSite);
    }
}
