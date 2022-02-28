using Abp.Application.Services;
using Fgv.Ide.Corporativohotsite.Dto;
using Fgv.Ide.Corporativohotsite.GenericResult;
using Fgv.Ide.Corporativohotsite.HotSite.Dto;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite
{
    public interface IHotSiteInCompanyAppService : IApplicationService
    {
        Task<OutputUploadBinaryObject> UploadBinaryObject(InputUploadBinaryObject input);

        Task<OutputDownloadObjectDto> DownloadBinaryObject(InputDownloadObjectDto input);

        Task<HotSiteInCompany> BuscarHotSiteInCompanyById(long id);

        Task<HotSiteInCompany> BuscarHotSiteInCompanyByNome(string nomeHotSite);

        

        Task<HotSiteInCompanyConfiguracao> BuscarConfiguracaoPorIdHotSite(long idHotSite);

        Task<HotSiteInCompanyConfiguracaoPublicado> BuscarConfiguracaoPublicadoPorIdHotSite(long idHotSite);

        Task<List<HotSiteInCompanyImagemCarrossel>> BuscarCarrosselPorIdHotSite(long idHotSite);

        Task<List<HotSiteInCompanyImagemCarrosselPublicado>> BuscarCarrosselPublicadoPorIdHotSite(long idHotSite);

        Task<HotSiteInCompanyMenu> BuscarMenuPorId(long idMenu);

        Task<List<InputBuscarMenuPorIdHotSite>> BuscarMenuPorIdHotSite(long idHotSite, bool usuarioLogado = false);

        Task<HotSiteInCompanyMenuPublicado> BuscarMenuPublicadoPorId(long idMenu);

        Task<List<InputBuscarMenuPublicadoPorIdHotSite>> BuscarMenuPublicadoPorIdHotSite(long idHotSite, bool usuarioLogado = false);

        Task<List<HotSiteInCompanyMenuDocumento>> BuscarMenuDocumentoPorIdMenu(long idMenu);

        Task<HotSiteInCompanyMenuDocumento> BuscarMenuDocumentoPorToken(string token);

        Task<List<HotSiteInCompanyMenuDocumentoPublicado>> BuscarMenuDocumentoPublicadoPorIdMenu(long idMenu);

        Task<HotSiteInCompanyMenuDocumentoPublicado> BuscarMenuDocumentoPublicadoPorToken(string token);

        Task<GenericResultObject<OutputInscrever>> Inscrever(InputInscrever input);

        Task<GenericVoid> VerificarLogin(string email, string senha, long idHotSite, string nomeHotSite);

        Task<HotSiteIncompanyLogin> BuscarLoginPorEmail(string email);

        Task<GenericResultObject<string>> RedefinirSenhaDeAcesso(long idHotsite, string email, string senha);

        Task<List<HotSiteInscritosDto>> BuscarInscritosPorTurma(string codigoTurma);
        Task<List<HotSiteInscritosDto>> BuscarInscritosPorHotSite(long idHotSite);
        Task<GenericResultObject<string>> HabilitarInscritos(InputInscricaoHabilitarDto _input);
        Task<GenericResultObject<string>> MudarSituacaoCandidato(InscricaoDto _input);

        Task<GenericResultObject<string>> RedirecionarGerenciarInscritos(InputHotSiteSSOGerenciarInscritoDto input);
        Task<GenericResultObject<List<HotSiteTurmaDto>>> BuscarTurmaPorIdHotSite(long idHotSite, string cpfPassaporte);
    }
}
