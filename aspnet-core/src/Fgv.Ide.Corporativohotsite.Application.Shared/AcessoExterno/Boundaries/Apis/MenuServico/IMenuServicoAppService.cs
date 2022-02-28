using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis.MenuServico.Dto;

namespace Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis.MenuServico
{
	public interface IMenuServicoAppService : IApplicationService
	{
		Task<List<Navigations.NavigationDto>> ObterItensDeMenuPorUsuarioEPapel(ObterItensDeMenuPorUsuarioEPapelInput input);
		Task<ItemMenuDto> ObterItemDeMenuPorId(ObterItemDeMenuPorIdInput input);
		Task AdicionarFavorito(AdicionarFavoritoInput input);
		Task RegistrarAcessoRecurso(RegistrarAcessoRecursoInput input);
		Task RemoverFavorito(RemoverFavoritoInput input);
		Task<Navigations.NavigationDto> ObterItemMenu(ObterItemMenuInput input);

	}
}
