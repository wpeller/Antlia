using Abp;
using MovimentosManuais.ApplicationCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite
{
    public class ProdutoCosifAppService : AbpServiceBase, IProdutoCosifAppService
    {

        private IProdutoCosifManager _produtoManager;


        public ProdutoCosifAppService(IProdutoCosifManager produtoManager)
        {
            _produtoManager = produtoManager;

        }


        public async Task<List<Produto_Cosif>> BuscarTodos()
        {
            return await this._produtoManager.BuscarTodos();
        }



        public async Task<List<Produto_Cosif>> BuscarPorIdProduto(string codProduto)
        {
            return await this._produtoManager.BuscarPorIdProduto(codProduto);
        }
    }


}
