using Abp.Domain.Repositories;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite
{
    public class HotSiteInCompanyTurmaComHabilitacaoManager : IHotSiteInCompanyTurmaComHabilitacaoManager
    {
        private readonly IRepository<HotSiteInCompanyTurmaComHabilitacao, long> _repository;

        public HotSiteInCompanyTurmaComHabilitacaoManager(IRepository<HotSiteInCompanyTurmaComHabilitacao, long> repository)
        {
            this._repository = repository;
        }


        public async Task<List<HotSiteInCompanyTurmaComHabilitacao>> BuscarPorIdHotSite(string cpfPassaporte, long idHotSite)
        {
            return this._repository.GetAll().Where(x => (x.CPF.Equals(cpfPassaporte) || x.Passaporte.Equals(cpfPassaporte)) && x.IdHotSiteIncompany == idHotSite).ToList();
        }

    }
}
