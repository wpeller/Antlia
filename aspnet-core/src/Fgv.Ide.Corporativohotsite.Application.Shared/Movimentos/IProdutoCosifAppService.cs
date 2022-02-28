using Abp.Application.Services;
using MovimentosManuais.ApplicationCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite
{
    public interface IProdutoCosifAppService : IApplicationService
    {
        Task<List<Produto_Cosif>> BuscarPorIdProduto(string codProduto);
    }
}