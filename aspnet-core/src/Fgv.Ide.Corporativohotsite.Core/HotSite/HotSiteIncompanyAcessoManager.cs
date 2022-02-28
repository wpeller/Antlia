using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Fgv.Ide.Corporativohotsite.HotSite.Interfaces;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite
{
    public class HotSiteIncompanyAcessoManager : IHotSiteIncompanyAcessoManager
    {
        private readonly IRepository<HotSiteIncompanyLogin, long> _repository;
        private readonly IRepository<HotSiteInCompany, long> _repositoryHotsite;
        private readonly IUnitOfWorkManager _unitOfWorkManager;


        public HotSiteIncompanyAcessoManager(IRepository<HotSiteIncompanyLogin, long> repository, 
            IRepository<HotSiteInCompany, long> repositoryHotsite, IUnitOfWorkManager unitOfWorkManager)
        {
            _repository = repository;
            _repositoryHotsite = repositoryHotsite;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task<HotSiteIncompanyLogin> Alterar(HotSiteIncompanyLogin loginHotsite)
        {
            var user = await this._repository.UpdateAsync(loginHotsite);
            await _unitOfWorkManager.Current.SaveChangesAsync();
            return user;

        }

        public async Task<HotSiteIncompanyLogin> Buscar(HotSiteIncompanyLogin acesso)
        {
            return await _repository.GetAll().Include(x=> x.HotSiteInCompany).Where(x => x.IdHotSiteIncompany == acesso.IdHotSiteIncompany && x.Email == acesso.Email).FirstOrDefaultAsync();
        }

        public async Task<HotSiteIncompanyLogin> BuscarPorEmail(string email)
        {
            return await _repository.GetAll().Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task<bool> ValidarLogin(string email, string password)
        {
            bool retorno = false;

            var user = await _repository.GetAll().Where(x => x.Email == email && x.Senha.Equals(password)).FirstOrDefaultAsync();
            if (user != null) { return true; }

           return retorno;
        }
    }
}
