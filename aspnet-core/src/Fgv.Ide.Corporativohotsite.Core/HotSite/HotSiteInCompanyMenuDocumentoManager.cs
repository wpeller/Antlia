using Abp.Domain.Repositories;
using Fgv.Ide.Corporativohotsite.HotSite.Interfaces;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite
{
    public class HotSiteInCompanyMenuDocumentoManager: IHotSiteInCompanyMenuDocumentoManager
    {
        private readonly IRepository<HotSiteInCompanyMenuDocumento, long> _repository;

        public HotSiteInCompanyMenuDocumentoManager(IRepository<HotSiteInCompanyMenuDocumento, long> repository)
        {
            this._repository = repository;
        }

        public async Task<HotSiteInCompanyMenuDocumento> BuscarPorId(long id)
        {
            return await _repository.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<HotSiteInCompanyMenuDocumento>> BuscarPorIdMenu(long idMenu)
        {
            return await this._repository.GetAll().Where(x => x.IdMenu == idMenu).ToListAsync();
        }

        public async Task<HotSiteInCompanyMenuDocumento> BuscarPorFileToken(string token)
        {
            return await this._repository.FirstOrDefaultAsync(x => x.Token == token);
        }
    }
}
