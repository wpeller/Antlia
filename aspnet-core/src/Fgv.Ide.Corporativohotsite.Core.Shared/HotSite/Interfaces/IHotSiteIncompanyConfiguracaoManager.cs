using Abp.Dependency;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite
{
    public interface IHotSiteInCompanyConfiguracaoManager : ITransientDependency
    {
        Task<HotSiteInCompanyConfiguracao> BuscarPorId(long id);
        Task<HotSiteInCompanyConfiguracao> BuscarPorIdHotSite(long idHotSite);
    }
}
