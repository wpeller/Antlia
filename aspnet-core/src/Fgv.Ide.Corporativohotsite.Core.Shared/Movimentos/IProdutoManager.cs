using Abp.Dependency;
using MovimentosManuais.ApplicationCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite
{
    public interface IProdutoManager : ITransientDependency
    {
        Task<List<Produto>> BuscarTodos();
    }
}