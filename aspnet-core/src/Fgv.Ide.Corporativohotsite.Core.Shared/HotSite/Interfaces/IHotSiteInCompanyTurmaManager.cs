using Abp.Dependency;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite.Interfaces
{
    public interface IHotSiteInCompanyTurmaManager : ITransientDependency
    {
        Task<HotSiteInCompanyTurma> BuscarPorId(long id);
        Task<List<HotSiteInCompanyTurma>> BuscarPorIdHotSite(long idHotSite);
    }
}
