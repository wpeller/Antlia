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
    public class MovimentoManager : IMovimentoManager
    {
        private readonly IRepository<Movimento_Manual, string > _repository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;


        public MovimentoManager(IRepository<Movimento_Manual, string > repository,  IUnitOfWorkManager unitOfWorkManager)
        {
            _repository = repository;
            _unitOfWorkManager = unitOfWorkManager;

        }
         

        public async Task<List<Movimento_Manual>> BuscarTodos()
        {
            return await _repository.GetAll()
                .Include(t => t.Produto).ThenInclude(ta => ta.Movimentos)
                .ToListAsync();
        }
 

        public async void Gravar(Movimento_Manual movimento)
        {

            if (movimento != null)
            {
                movimento.NUM_LANCAMENTO = this.ObterDataLancamentoAsync(movimento.DAT_ANO, movimento.DAT_MES);
                movimento.DAT_MOVIMENTO = DateTime.Now;


                 Movimento_Manual output = await _repository.InsertAsync(movimento);
                _unitOfWorkManager.Current.SaveChanges();
                 
            }             
             
        }

        private  decimal ObterDataLancamentoAsync(decimal dAT_ANO, decimal dAT_MES)
        {
            return _repository.GetAll()
                 .Include(t => t.Produto ).ThenInclude(ta => ta.Movimentos)
                .Where(x=> x.DAT_ANO == dAT_ANO && x.DAT_MES == dAT_MES)
                .OrderBy(x=> x.NUM_LANCAMENTO)
                .Select(x => x.NUM_LANCAMENTO).FirstOrDefault()+1;
                        
        }
    }
}
