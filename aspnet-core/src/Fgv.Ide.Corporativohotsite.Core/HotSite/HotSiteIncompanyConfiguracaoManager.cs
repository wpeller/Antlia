using Abp.Domain.Repositories;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite
{
    public class HotSiteInCompanyConfiguracaoManager : IHotSiteInCompanyConfiguracaoManager
    {
        private readonly IRepository<HotSiteInCompanyConfiguracao, long> _repository;

        public HotSiteInCompanyConfiguracaoManager(IRepository<HotSiteInCompanyConfiguracao, long> repository            )
        {
            this._repository = repository;
        }

        public async Task<HotSiteInCompanyConfiguracao> BuscarPorId(long id)
        {
            return await _repository.FirstOrDefaultAsync(x=> x.Id == id);
        }

        public async Task<HotSiteInCompanyConfiguracao> BuscarPorIdHotSite(long idHotSiteInCompany)
        {
            return await this._repository.FirstOrDefaultAsync(x => x.IdHotSiteIncompany == idHotSiteInCompany);
        }       
    }
}
