using Abp.Dependency;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite
{
    public interface IHotSiteInCompanyTurmaComHabilitacaoManager : ITransientDependency
    {
        Task<List<HotSiteInCompanyTurmaComHabilitacao>> BuscarPorIdHotSite(string cpfPassaporte, long idHotSite);
    }
}