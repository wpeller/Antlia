using Abp.Application.Services;
using Fgv.Ide.Corporativohotsite.GenericResult;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite
{
    public interface IMovimentoAppService : IApplicationService
    {
        Task<List<Movimento_ManualResultDto>> BuscarTodos();
        Task<GenericVoid> Gravar(Movimento_ManualDto movimentoDto);
    }
}