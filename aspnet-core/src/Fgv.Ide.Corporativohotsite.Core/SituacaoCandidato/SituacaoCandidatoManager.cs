using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Fgv.Ide.Corporativohotsite.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.SituacaoCandidatoManager
{
    public class SituacaoCandidatoManager : ISituacaoCandidatoManager
    {
        private readonly IRepository<Table.SituacaoCandidato, long> _repository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public SituacaoCandidatoManager(
            IRepository<Table.SituacaoCandidato, long> repository,
            IUnitOfWorkManager unitOfWorkManager)
        {
            _repository = repository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public async Task<Table.SituacaoCandidato> BuscarSituacaoCandidatoPorDescricao(string _descricaoSituacaoCandidato)
        {
            var situacaoCandidato = await _repository.GetAll().Where(x => x.Descricao.Equals(_descricaoSituacaoCandidato)).FirstOrDefaultAsync();
                
            return situacaoCandidato;
        }
    }
}
