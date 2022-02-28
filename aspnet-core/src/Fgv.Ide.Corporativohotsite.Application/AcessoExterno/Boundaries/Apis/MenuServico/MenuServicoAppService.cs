using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis.MenuServico.Dto;
using Fgv.Ide.Corporativohotsite.Navigations;

namespace Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis.MenuServico
{
	public class MenuServicoAppService : IMenuServicoAppService
	{
		private readonly IHttpClientApiRequest _httpClientApiRequest;
		private readonly ConfigurationResolver _configurationResolver;
		private HttpClientConfigurationResolverOutput _httpClientConfigurationResolver;

		public MenuServicoAppService(IHttpClientApiRequest httpClientApiRequest, ConfigurationResolver configurationResolver)
		{
			_httpClientApiRequest = httpClientApiRequest;
			_configurationResolver = configurationResolver;
			_httpClientConfigurationResolver =
				_configurationResolver.Get("Siga2", "URLsWebApiBoundaries", "Administracao");
		}


		public async Task<List<NavigationDto>> ObterItensDeMenuPorUsuarioEPapel(ObterItensDeMenuPorUsuarioEPapelInput input)
		{
			var httpConfig = new HttpClientApiRequestInput<ObterItensDeMenuPorUsuarioEPapelInput>()
			{
				InputRequest = input,
				Method = new HttpClientApiMethod("POST"),
				ApplicationName = "BoundarieAdmnistracao",
				Url = _httpClientConfigurationResolver.Url,
				ApiUserName = _httpClientConfigurationResolver.UserName,
				ApiUserNamePassword = _httpClientConfigurationResolver.Password,
				ApiService = "api/services/app/S2Menu/ObterItensDeMenuPorUsuarioEPapel"
			};

			var output =
				await _httpClientApiRequest.SendAsync<ObterItensDeMenuPorUsuarioEPapelInput, List<NavigationDto>>(
					httpConfig);

			return output;
		}

		public async Task<ItemMenuDto> ObterItemDeMenuPorId(ObterItemDeMenuPorIdInput input)
		{
			var httpConfig = new HttpClientApiRequestInput<ObterItemDeMenuPorIdInput>()
			{
				InputRequest = input,
				Method = new HttpClientApiMethod("POST"),
				ApplicationName = "BoundarieAdmnistracao",
				Url = _httpClientConfigurationResolver.Url,
				ApiUserName = _httpClientConfigurationResolver.UserName,
				ApiUserNamePassword = _httpClientConfigurationResolver.Password,
				ApiService = "api/services/app/S2Menu/ObterItemDeMenuPorId"
			};

			var output =
				await _httpClientApiRequest.SendAsync<ObterItemDeMenuPorIdInput, ItemMenuDto>(
					httpConfig);

			return output;
		}

		public async Task AdicionarFavorito(AdicionarFavoritoInput input)
		{
			var httpConfig = new HttpClientApiRequestInput<AdicionarFavoritoInput>()
			{
				InputRequest = input,
				Method = new HttpClientApiMethod("POST"),
				ApplicationName = "BoundarieAdmnistracao",
				Url = _httpClientConfigurationResolver.Url,
				ApiUserName = _httpClientConfigurationResolver.UserName,
				ApiUserNamePassword = _httpClientConfigurationResolver.Password,
				ApiService = "api/services/app/S2Menu/AdicionarFavorito"
			};

			var output =
				await _httpClientApiRequest.SendAsync<AdicionarFavoritoInput>(
					httpConfig);
		}

		public async Task RegistrarAcessoRecurso(RegistrarAcessoRecursoInput input)
		{
			var httpConfig = new HttpClientApiRequestInput<RegistrarAcessoRecursoInput>()
			{
				InputRequest = input,
				Method = new HttpClientApiMethod("POST"),
				ApplicationName = "BoundarieAdmnistracao",
				Url = _httpClientConfigurationResolver.Url,
				ApiUserName = _httpClientConfigurationResolver.UserName,
				ApiUserNamePassword = _httpClientConfigurationResolver.Password,
				ApiService = "api/services/app/S2Menu/RegistrarAcessoRecurso"
			};

			var output =
				await _httpClientApiRequest.SendAsync<RegistrarAcessoRecursoInput>(
					httpConfig);
		}

		public async Task RemoverFavorito(RemoverFavoritoInput input)
		{
			var httpConfig = new HttpClientApiRequestInput<RemoverFavoritoInput>()
			{
				InputRequest = input,
				Method = new HttpClientApiMethod("Delete"),
				ApplicationName = "BoundarieAdmnistracao",
				Url = _httpClientConfigurationResolver.Url,
				ApiUserName = _httpClientConfigurationResolver.UserName,
				ApiUserNamePassword = _httpClientConfigurationResolver.Password,
				ApiService = "api/services/app/S2Menu/RemoverFavorito"
			};

			var output =
				await _httpClientApiRequest.SendAsync<RemoverFavoritoInput>(
					httpConfig);
		}

		public async Task<NavigationDto> ObterItemMenu(ObterItemMenuInput input)
		{
			var httpConfig = new HttpClientApiRequestInput<ObterItemMenuInput>()
			{
				InputRequest = input,
				Method = new HttpClientApiMethod("POST"),
				ApplicationName = "BoundarieAdmnistracao",
				Url = _httpClientConfigurationResolver.Url,
				ApiUserName = _httpClientConfigurationResolver.UserName,
				ApiUserNamePassword = _httpClientConfigurationResolver.Password,
				ApiService = "api/services/app/S2Menu/ObterItemMenu"
			};

			var output =
				await _httpClientApiRequest.SendAsync<ObterItemMenuInput, NavigationDto>(
					httpConfig);
			return output;
		}
	}
}
