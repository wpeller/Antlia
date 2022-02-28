using System.Threading.Tasks;
using Abp.Application.Services;
using Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis.UsuarioServico.Dto;

namespace Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis.UsuarioServico
{
	public interface IUsuarioServicoAppService : IApplicationService
	{
		Task<AutenticarOutput> Autenticar(AutenticarInput autenticarInput);
		Task<UsuarioSigaDoisDto> ObterUsuarioPorCodigoExterno(string user);
		Task<RetornoOutputDto> AlterarSenhaUsuarioLogado(TrocaDeSenhaInput input);
        Task<RetornoOutputDto> ValidaUsuarioTemPermissao(ValidaUsuarioTemPermissaoDto _validar);

    }

}
