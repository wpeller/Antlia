using Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis.DashboardServico;
using Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis.UsuarioServico;
using Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis.UsuarioServico.Dto;
using Shouldly;
using System.Threading.Tasks;
using Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis.PapelServico.Dto;
using Xunit;

namespace Fgv.Ide.Corporativohotsite.Tests.AcessoExterno.Boundaries.Apis
{
	public class DashboardServicoAppService_Tests : AppTestBase
	{

		private readonly IDashboardServicoAppService _dashboradServicoAppService;
		public DashboardServicoAppService_Tests()
		{
			_dashboradServicoAppService = Resolve<IDashboardServicoAppService>();
		}

		[Fact]
		public async Task devo_obter_a_lista_de_documentos_com_sucesso()
		{
			var output =await _dashboradServicoAppService.ObterCategoriasDeDocumentos();
			output.Count.ShouldBeGreaterThanOrEqualTo(1);
		}

		[Fact(Skip = "Erro buscar, solicitado para ignorar.")]
		public async Task devo_obter_lista_de_avisos_do_papel_com_sucesso()
		{
			var output = await _dashboradServicoAppService.ObterAvisosDoPapel(new PapelDto()
			{
				Mnemonico = "COL-SECACAD-RIO1"
			});
			output.Count.ShouldBeGreaterThanOrEqualTo(1);
		}

		[Fact]
		public async Task devo_obter_lista_de_recursos_favoritos_com_sucesso()
		{
			var output = await _dashboradServicoAppService.ObterRecursosFavoritos("JEANLUC", new PapelDto()
			{
				Id = 904,
				Mnemonico = "COL-FGVMGMSP1"
			});

			output.Count.ShouldBeGreaterThanOrEqualTo(1);
		}

		[Fact]
		public async Task devo_obter_lista_de_recursos_mais_visitados_com_sucesso()
		{
			var output = await _dashboradServicoAppService.ObterRecursosFavoritos("JEANLUC", new PapelDto()
			{
				Id = 904,
				Mnemonico = "COL-FGVMGMSP1"
			});

			output.Count.ShouldBeGreaterThanOrEqualTo(1);
		}

	}
}
