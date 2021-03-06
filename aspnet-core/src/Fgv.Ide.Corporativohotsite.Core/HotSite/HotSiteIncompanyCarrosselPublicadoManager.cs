using Abp.Domain.Repositories;
using Fgv.Ide.Corporativohotsite.HotSite.Interfaces;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite
{
    public class HotSiteInCompanyCarrosselPublicadoManager : IHotSiteInCompanyCarrosselPublicadoManager
    {
        private readonly IRepository<HotSiteInCompanyImagemCarrosselPublicado, long> _repository;

        public HotSiteInCompanyCarrosselPublicadoManager(IRepository<HotSiteInCompanyImagemCarrosselPublicado, long> repository            )
        {
            this._repository = repository;
        }

        public async Task<HotSiteInCompanyImagemCarrosselPublicado> BuscarPorId(long id)
        {
            return await _repository.FirstOrDefaultAsync(x=> x.Id == id);
        }

        public async Task<List<HotSiteInCompanyImagemCarrosselPublicado>> BuscarPorIdHotSite(long idHotSite)
        {
            return await this._repository.GetAll().Where(x => x.IdHotSiteIncompany == idHotSite).ToListAsync();
        }

        public async Task<HotSiteInCompanyImagemCarrosselPublicado> BuscarPorFileToken(string token)
        {
            return await this._repository.FirstOrDefaultAsync(x => x.Token == token);
        }
    }
}
