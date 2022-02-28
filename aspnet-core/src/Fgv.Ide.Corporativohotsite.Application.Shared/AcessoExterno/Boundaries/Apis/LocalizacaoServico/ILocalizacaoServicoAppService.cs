using Abp.Application.Services;
using Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis.LocalizacaoServico.Dto;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis.LocalizacaoServico
{
    public interface ILocalizacaoServicoAppService : IApplicationService
    {
        Task<ValidarGlobalizacaoDto> ValidarGlobalizacao(ValidarGlobalizacaoDto _validar);
    }
}
