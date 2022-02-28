using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis.DashboardServico.Dto;
using Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis.PapelServico.Dto;
using Fgv.Ide.Corporativohotsite.Navigations;

namespace Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis.DashboardServico
{
	public interface IDashboardServicoAppService : IApplicationService
	{
		Task<List<CategoriaDocumentoSigaDto>> ObterCategoriasDeDocumentos();
		Task<List<AvisoDto>> ObterAvisosDoPapel(PapelDto papel);
		Task<List<NavigationDto>> ObterRecursosFavoritos(string codigoExternoUsuario, PapelDto papel);
		Task<List<AcessoRecursoDto>> ObterMaisVisitados(string codigoExternoUsuario, PapelDto papel);
		Task<byte[]> DownloadDocumento(DocumentoSigaDto input);
		Task<List<DocumentoSigaDto>> ObterListaDeDocumentosPorCategoria(long idCategoria);
	}
}
