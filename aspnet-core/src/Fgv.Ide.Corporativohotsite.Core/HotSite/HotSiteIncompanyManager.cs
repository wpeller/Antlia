using Abp.Domain.Repositories;
using Fgv.Ide.Corporativohotsite.HotSite.Interfaces;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite
{
    public class HotSiteIncompanyManager : IHotSiteIncompanyManager
    {
        private readonly IRepository<HotSiteInCompany, long> _repositoryHotSite;

        public HotSiteIncompanyManager(IRepository<HotSiteInCompany, long> repositoryHotSite)
        {
            this._repositoryHotSite = repositoryHotSite;
        }

        public async Task<HotSiteInCompany> BuscarHotSitePorId(long id)
        {
            return await this._repositoryHotSite.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<HotSiteInCompany> BuscarHotSitePorNome(string nomeHotSite)
        {
            return await this._repositoryHotSite.FirstOrDefaultAsync(x => x.NomeHotSite == nomeHotSite);
        }
    }
}
