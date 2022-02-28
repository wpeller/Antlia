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
    public class ProdutoManager : IProdutoManager
    {
        private readonly IRepository<Produto,string> _repository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;


        public ProdutoManager(IRepository<Produto,string > repository,  IUnitOfWorkManager unitOfWorkManager)
        {
            _repository = repository;
            _unitOfWorkManager = unitOfWorkManager;

        }
         

        public async Task<List<Produto>> BuscarTodos()
        {
            return await _repository.GetAll().ToListAsync();
        }




         
    }
}
