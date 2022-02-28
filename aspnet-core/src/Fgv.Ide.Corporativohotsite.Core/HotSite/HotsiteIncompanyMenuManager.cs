using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Fgv.Ide.Corporativohotsite.HotSite.Interfaces;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite
{
    public class HotSiteInCompanyMenuManager : IHotSiteInCompanyMenuManager
    {
        private readonly IRepository<HotSiteInCompanyMenu, long> _repository;

        public HotSiteInCompanyMenuManager(IRepository<HotSiteInCompanyMenu, long> repository)
        {
            this._repository = repository;
        }

        public async Task<HotSiteInCompanyMenu> BuscarPorId(long idMenu)
        {
            return await this._repository.FirstOrDefaultAsync(x => x.Id == idMenu);
        }

        public async Task<List<HotSiteInCompanyMenu>> BuscarPorIdHotSite(long idHotSite, bool usuarioLogado)
        {
            return await this._repository.GetAll()
                .WhereIf(!usuarioLogado, x => !x.Restrito.GetValueOrDefault())
                .Where(x => x.IdHotSiteIncompany == idHotSite && x.Ativo == true && x.IdMenuPai == null)
                .Include(x => x.SubMenus)
                .ToListAsync();
        }
    }
}
