using Abp.Dependency;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite.Interfaces
{
    public interface IOpcaoOfertaManager : ITransientDependency
    {
        Task<OpcaoOferta> BuscarPorId(long id);
        Task<OpcaoOferta> BuscarPorTurma(string codigoTurma);
    }
}