using Abp.Dependency;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite
{
    public interface IHotSiteInCompanyConfiguracaoPublicadoManager : ITransientDependency
    {
        Task<HotSiteInCompanyConfiguracaoPublicado> BuscarPorId(long id);
        Task<HotSiteInCompanyConfiguracaoPublicado> BuscarPorIdHotSite(long idHotSite);
    }
}
