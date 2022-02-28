using System.Threading.Tasks;
using Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis.MenuServico;
using Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis.MenuServico.Dto;
using Shouldly;
using Xunit;

namespace Fgv.Ide.Corporativohotsite.Tests.AcessoExterno.Boundaries.Apis
{
	public class MenuServicoAppService_Tests : AppTestBase
	{

		private readonly IMenuServicoAppService _menuServicoAppService;
		public MenuServicoAppService_Tests()
		{
			_menuServicoAppService = Resolve<IMenuServicoAppService>();

		}

		//[Fact]
		//public async Task devo_obter_itens_de_menu_por_usuario_e_papel_com_sucesso()
		//{
		//	var output = await _menuServicoAppService.ObterItensDeMenuPorUsuarioEPapel(
		//		new ObterItensDeMenuPorUsuarioEPapelInput()
		//		{
		//			CodigoExternoUsuario = "JEANLUC",
		//			IdPapel = 11593
		//		});

		//	output.Count.ShouldBeGreaterThanOrEqualTo(1);
		//}

		//[Fact]
		//public async Task devo_obter_item_menu_por_id_com_sucesso()
		//{
		//	var output = await _menuServicoAppService.ObterItemDeMenuPorId(new ObterItemDeMenuPorIdInput()
		//	{
		//		IdItemMenu = 5330
		//	});
		//	output.ShouldNotBeNull();
		//}

		//[Fact]
		//public async Task devo_adicionar_o_item_menu_como_favorito_com_sucesso()
		//{
		//	await _menuServicoAppService.AdicionarFavorito(new AdicionarFavoritoInput()
		//	{
		//		CodigoExternoUsuario = "JEANLUC",
		//		IdPapel = 11593,
		//		IdRecurso = 5330 //codigo do item de menu
		//	});

		//}

		//[Fact]
		//public async Task devo_registrar_acesso_do_recurso_com_sucesso()
		//{
		//	await _menuServicoAppService.RegistrarAcessoRecurso(new RegistrarAcessoRecursoInput()
		//	{
		//		CodigoExternoUsuario = "JEANLUC",
		//		IdPapel = 11593,
		//		IdItemMenu = 5330 //codigo do item de menu
		//	});
		//}

		//[Fact]
		//public async Task devo_remover_recurso_como_favorito_com_sucesso()
		//{
		//	await _menuServicoAppService.RemoverFavorito(new RemoverFavoritoInput()
		//	{
		//		CodigoExternoUsuario = "JEANLUC",
		//		IdPapel = 11593,
		//		idItemMenu = 5330 //codigo do item de menu
		//	});
		//}

		//[Fact]
		//public async Task devo_obter_item_menu_por_rota_com_sucesso()
		//{
		//	var output = await _menuServicoAppService.ObterItemMenu(new ObterItemMenuInput()
		//	{
		//		Rota = "app/administracao/usuario/cadastro"
		//	});

		//	output.ShouldNotBeNull();

		//}

	}
}
