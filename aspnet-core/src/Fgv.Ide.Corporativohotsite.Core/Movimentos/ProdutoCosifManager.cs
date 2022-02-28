using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Fgv.Ide.Corporativohotsite.HotSite.Interfaces;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using Microsoft.EntityFrameworkCore;
using MovimentosManuais.ApplicationCore;
using MovimentosManuais.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite
{
    public class ProdutoCosifManager : IProdutoCosifManager
    {
        private readonly IRepository<Produto_Cosif,string > _repository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;


        public ProdutoCosifManager(IRepository<Produto_Cosif,string > repository,  IUnitOfWorkManager unitOfWorkManager)
        {
            _repository = repository;
            _unitOfWorkManager = unitOfWorkManager;

        }
         

        public async Task<List<Produto_Cosif>> BuscarTodos()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<List<Produto_Cosif>> BuscarPorIdProduto(string codProduto)
        {
            return await _repository.GetAll().Where(x => x.COD_PRODUTO.Equals(codProduto)) .ToListAsync();
        }


    }
}
