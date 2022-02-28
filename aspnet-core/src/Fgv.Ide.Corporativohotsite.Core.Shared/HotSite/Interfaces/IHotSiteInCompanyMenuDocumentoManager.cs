using Abp.Dependency;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite.Interfaces
{
    public interface IHotSiteInCompanyMenuDocumentoManager : ITransientDependency
    {
        Task<HotSiteInCompanyMenuDocumento> BuscarPorId(long id);
        Task<List<HotSiteInCompanyMenuDocumento>> BuscarPorIdMenu(long idMenu);
        Task<HotSiteInCompanyMenuDocumento> BuscarPorFileToken(string token);
    }
}
