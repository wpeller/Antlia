using Abp.Dependency;
using MovimentosManuais.ApplicationCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite
{
    public interface IProdutoCosifManager : ITransientDependency
    {
        Task<List<Produto_Cosif>> BuscarPorIdProduto(string codProduto);
        Task<List<Produto_Cosif>> BuscarTodos();
    }
}