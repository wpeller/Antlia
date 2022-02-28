using Abp.Domain.Repositories;
using Fgv.Ide.Corporativohotsite.HotSite.Interfaces;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite
{
    public class OpcaoOfertaManager : IOpcaoOfertaManager
    {
        private readonly IRepository<OpcaoOferta, long> _repositoryHotSite;

        public OpcaoOfertaManager(IRepository<OpcaoOferta, long> repositoryHotSite)
        {
            this._repositoryHotSite = repositoryHotSite;
        }

        public async Task<OpcaoOferta> BuscarPorId(long id)
        {
            return await this._repositoryHotSite.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<OpcaoOferta> BuscarPorTurma(string codigoTurma)
        {
            return await this._repositoryHotSite.FirstOrDefaultAsync(x => x.Turma == codigoTurma);
        }
    }
}
