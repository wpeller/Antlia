using Abp.Dependency;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite.Interfaces
{
    public interface IHotSiteInCompanyMenuPublicadoManager : ITransientDependency
    {
        Task<HotSiteInCompanyMenuPublicado> BuscarPorId(long idMenu);
        Task<List<HotSiteInCompanyMenuPublicado>> BuscarPorIdHotSite(long idHotSite, bool usuarioLogado);
    }
}
