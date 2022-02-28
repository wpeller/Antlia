using Abp.Dependency;
using Fgv.Ide.Corporativohotsite.HotSite.View;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite.Interfaces
{
    public interface IVwHotsiteHabilitacaoPreviaInscricaoManager : ITransientDependency
    {
        Task<HotSiteHabilitacaoPrevia> BuscarPorId(long id);
        Task<List<HotSiteHabilitacaoPrevia>> Buscar(string cpf, string codigoTurma);
    }
}
