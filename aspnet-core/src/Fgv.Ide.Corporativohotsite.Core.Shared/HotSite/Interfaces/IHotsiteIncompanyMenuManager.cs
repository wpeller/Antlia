using Abp.Dependency;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite.Interfaces
{
    public interface IHotSiteInCompanyMenuManager : ITransientDependency
    {
        Task<HotSiteInCompanyMenu> BuscarPorId(long idMenu);
        Task<List<HotSiteInCompanyMenu>> BuscarPorIdHotSite(long idHotSite, bool usuarioLogado);
    }
}
