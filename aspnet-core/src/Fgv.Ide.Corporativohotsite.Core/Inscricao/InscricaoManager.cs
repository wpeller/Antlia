using Abp.Domain.Repositories;
using Fgv.Ide.Corporativohotsite.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Fgv.Ide.Corporativohotsite.Table;
using Abp.Domain.Uow;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Fgv.Ide.Corporativohotsite.Dto;

namespace Fgv.Ide.Corporativohotsite
{
    public class InscricaoManager : IInscricaoManager
    {
        private readonly IRepository<Inscricao, long> _repository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public InscricaoManager(
            IRepository<Inscricao, long> repository, 
            IUnitOfWorkManager unitOfWorkManager)
        {
            _repository = repository;           
            _unitOfWorkManager = unitOfWorkManager;
        }

        public async Task<Inscricao> BuscarInscricaoPorCPFIdOfertaIdOpcaoOferta(string cpf, long idOferta, long idOpcaoOferta)
        {
            var insc = await _repository.GetAll().Where(x => x.Cpf.Equals(cpf) && x.IdOferta == idOferta && x.IdOpcaoOferta == idOpcaoOferta).FirstOrDefaultAsync();
            return insc;

        }

        public async Task<bool> MudarSituacaoInscricaoCandidato(List<InputInscricao> _lstInscricao)
        {
            bool _retorno = false;

            foreach (var i in _lstInscricao)
            {
                //var _inscr = await BuscarInscricaoPorCPFIdOfertaIdOpcaoOferta(i.Cpf, i.IdOferta, i.IdOpcaoOferta);
                var _inscr = _repository.GetAll().Where(x => x.Cpf.Equals(i.Cpf) && x.IdOferta == i.IdOferta && x.IdOpcaoOferta == i.IdOpcaoOferta).FirstOrDefault();
                if (_inscr != null)
                {
                    _inscr.IdSituacaoCandidato = i.NovoIdSituacaoCandidato;                   
                    await _repository.UpdateAsync(_inscr);                    
                }
                _retorno = true;
            }
            _unitOfWorkManager.Current.SaveChanges();
            return _retorno;
        }

        public async Task<bool> MudarSituacaoInscricaoCandidato(InputInscricao _inscricao)
        {
            bool _retorno = false;
            
            var _inscr = _repository.GetAll().Where(x => x.Cpf.Equals(_inscricao.Cpf) && x.IdOferta == _inscricao.IdOferta && x.IdOpcaoOferta == _inscricao.IdOpcaoOferta).FirstOrDefault();
            if (_inscr != null)
            {
                _inscr.IdSituacaoCandidato = _inscricao.NovoIdSituacaoCandidato;
                await _repository.UpdateAsync(_inscr);
            }
            _retorno = true;
            
            _unitOfWorkManager.Current.SaveChanges();
            return _retorno;
        }

    }
}
