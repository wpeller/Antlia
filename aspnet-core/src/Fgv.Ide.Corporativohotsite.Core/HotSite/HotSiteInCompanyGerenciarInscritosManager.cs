using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Fgv.Ide.Corporativohotsite.HotSite.Interfaces;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using Fgv.Ide.Corporativohotsite.HotSite.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite
{
    public class HotSiteInCompanyGerenciarInscritosManager : IHotSiteInCompanyGerenciarInscritosManager
    {
        private readonly IRepository<InfoGerenciarInscritosHotSiteIncompany> _repository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public HotSiteInCompanyGerenciarInscritosManager(
            IRepository<InfoGerenciarInscritosHotSiteIncompany> repository,
            IUnitOfWorkManager unitOfWorkManager)
        {
            _repository = repository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public async Task<List<InfoGerenciarInscritosHotSiteIncompany>> BuscarInscritosPorCodigoTurma(string codigoTurma)
        {
            return await _repository.GetAll().Where(x => x.Turma == codigoTurma).ToListAsync();
        }

        public async Task<List<InfoGerenciarInscritosHotSiteIncompany>> BuscarInscritosPorHotSite(long idHotSite)
        {
            List<InfoGerenciarInscritosHotSiteIncompany> infoTurmas = new List<InfoGerenciarInscritosHotSiteIncompany>();

            infoTurmas = await _repository.GetAll().AsNoTracking().Where(x => x.IdHotSite == idHotSite).ToListAsync();
            return infoTurmas.OrderBy(o => o.Turma).ToList();            
        }
        public async Task<List<InfoGerenciarInscritosHotSiteIncompany>> BuscarInscritosPorProjeto(long idProjeto)
        {
            return await _repository.GetAll().Where(x => x.IdProjetoIncompany == idProjeto).ToListAsync();
        }
    }
}
