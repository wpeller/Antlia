using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Fgv.Ide.Corporativohotsite.HotSite.Interfaces;
using Fgv.Ide.Corporativohotsite.HotSite.View;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite
{
    class VwHotsiteHabilitacaoPreviaInscricaoManager : IVwHotsiteHabilitacaoPreviaInscricaoManager
    {
        private readonly IRepository<HotSiteHabilitacaoPrevia, long> _repository;

        public VwHotsiteHabilitacaoPreviaInscricaoManager(IRepository<HotSiteHabilitacaoPrevia, long> repository)
        {
            this._repository = repository;
        }

        public async Task<HotSiteHabilitacaoPrevia> BuscarPorId(long id)
        {
            return await _repository.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<HotSiteHabilitacaoPrevia>> Buscar(string cpf, string codigoTurma)
        {
            return await this._repository.GetAll()
                .WhereIf(!string.IsNullOrWhiteSpace(cpf), x => x.CPF == cpf)
                .WhereIf(!string.IsNullOrWhiteSpace(codigoTurma), x => x.Turma == codigoTurma)
                .ToListAsync();
        }
    }
}
