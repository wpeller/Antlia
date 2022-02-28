using Abp.Dependency;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite.Interfaces
{
    public interface IHotSiteInCompanyCarrosselManager : ITransientDependency
    {
        Task<HotSiteInCompanyImagemCarrossel> BuscarPorId(long id);
        Task<HotSiteInCompanyImagemCarrossel> BuscarPorFileToken(string token);
        Task<List<HotSiteInCompanyImagemCarrossel>> BuscarPorIdHotSite(long idHotSite);
    }
}
