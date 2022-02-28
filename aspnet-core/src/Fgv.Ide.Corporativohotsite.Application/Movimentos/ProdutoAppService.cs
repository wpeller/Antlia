using Abp;
using MovimentosManuais.ApplicationCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite
{
    public class ProdutoAppService : AbpServiceBase, IProdutoAppService
    {

        private IProdutoManager _produtoManager;


        public ProdutoAppService(IProdutoManager produtoManager)
        {
            _produtoManager = produtoManager;

        }


        public async Task<List<Produto>> BuscarTodos()
        {
            return await this._produtoManager.BuscarTodos();
        }
    }


}
