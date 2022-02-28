using Fgv.Ide.Corporativohotsite.HotSite.Table;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite.Interfaces
{
    public interface IHotSiteInCompanyMenuDocumentoPublicadoManager
    {
        Task<HotSiteInCompanyMenuDocumentoPublicado> BuscarPorId(long id);
        Task<List<HotSiteInCompanyMenuDocumentoPublicado>> BuscarPorIdMenu(long idMenu);
        Task<HotSiteInCompanyMenuDocumentoPublicado> BuscarPorFileToken(string token);
    }
}
