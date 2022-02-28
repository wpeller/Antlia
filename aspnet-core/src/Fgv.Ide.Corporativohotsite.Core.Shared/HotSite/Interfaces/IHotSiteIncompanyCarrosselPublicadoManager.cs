using Abp.Dependency;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite.Interfaces
{
    public interface IHotSiteInCompanyCarrosselPublicadoManager : ITransientDependency
    {
        Task<HotSiteInCompanyImagemCarrosselPublicado> BuscarPorId(long id);
        Task<HotSiteInCompanyImagemCarrosselPublicado> BuscarPorFileToken(string token);
        Task<List<HotSiteInCompanyImagemCarrosselPublicado>> BuscarPorIdHotSite(long idHotSite);
    }
}
