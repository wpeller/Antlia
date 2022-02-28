using Abp.Domain.Repositories;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite
{
    public class HotSiteInCompanyConfiguracaoPublicadoManager : IHotSiteInCompanyConfiguracaoPublicadoManager
    {
        private readonly IRepository<HotSiteInCompanyConfiguracaoPublicado, long> _repositoryHotSiteConfiguracaoPublicado;

        public HotSiteInCompanyConfiguracaoPublicadoManager(IRepository<HotSiteInCompanyConfiguracaoPublicado, long> repositoryHotSiteConfiguracaoPublicado)
        {
            this._repositoryHotSiteConfiguracaoPublicado = repositoryHotSiteConfiguracaoPublicado;
        }

        public async Task<HotSiteInCompanyConfiguracaoPublicado> BuscarPorId(long id)
        {
            return await _repositoryHotSiteConfiguracaoPublicado.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<HotSiteInCompanyConfiguracaoPublicado> BuscarPorIdHotSite(long idHotSiteInCompany)
        {
            return await this._repositoryHotSiteConfiguracaoPublicado.FirstOrDefaultAsync(x => x.IdHotSiteIncompany == idHotSiteInCompany);
        }
    }
}
