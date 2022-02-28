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
    public class HotSiteInCompanyMenuPublicadoManager : IHotSiteInCompanyMenuPublicadoManager
    {

        private readonly IRepository<HotSiteInCompanyMenuPublicado, long> _repository;

        public HotSiteInCompanyMenuPublicadoManager(IRepository<HotSiteInCompanyMenuPublicado, long> repository)
        {
            this._repository = repository;
        }

        public async Task<HotSiteInCompanyMenuPublicado> BuscarPorId(long idMenu)
        {
            return await this._repository.FirstOrDefaultAsync(x => x.Id == idMenu);
        }

        public async Task<List<HotSiteInCompanyMenuPublicado>> BuscarPorIdHotSite(long idHotSite, bool usuarioLogado)
        {
            return await this._repository.GetAll()
                .WhereIf(!usuarioLogado, x => !x.Restrito.GetValueOrDefault())
                .Where(x => x.IdHotSiteIncompany == idHotSite && x.Ativo == true && x.IdMenuPai == null)
                .Include(x=> x.SubMenus)
                .ToListAsync();
        }
    }
}
