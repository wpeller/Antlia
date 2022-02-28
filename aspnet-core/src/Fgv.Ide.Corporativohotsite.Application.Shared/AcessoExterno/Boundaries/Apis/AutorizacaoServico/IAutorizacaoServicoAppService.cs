using System.Threading.Tasks;
using Abp.Application.Services;
using Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis.AutorizacaoServico.Dto;

namespace Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis.AutorizacaoServico
{
    public interface IAutorizacaoServicoAppService : IApplicationService
    {
        Task<FuncionalidadesPermissoes> ObterPermissoes(AutorizacaoInput input);
    }
}
