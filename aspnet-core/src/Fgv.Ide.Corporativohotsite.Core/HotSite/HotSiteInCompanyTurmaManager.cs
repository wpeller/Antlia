using Abp.Domain.Repositories;
using Fgv.Ide.Corporativohotsite.HotSite.Interfaces;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite
{
    public class HotSiteInCompanyTurmaManager: IHotSiteInCompanyTurmaManager
    {
        private readonly IRepository<HotSiteInCompanyTurma, long> _repository;

        public HotSiteInCompanyTurmaManager(IRepository<HotSiteInCompanyTurma, long> repository)
        {
            this._repository = repository;
        }

        public async Task<HotSiteInCompanyTurma> BuscarPorId(long id)
        {
            return await _repository.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<HotSiteInCompanyTurma>> BuscarPorIdHotSite(long idHotSiteInCompany)
        {
            return await this._repository.GetAll().Where(x => x.IdHotSiteIncompany == idHotSiteInCompany).ToListAsync();
        }
    }
}
