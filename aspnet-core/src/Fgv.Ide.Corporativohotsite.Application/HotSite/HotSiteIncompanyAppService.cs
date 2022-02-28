using Abp;
using Abp.UI;
using Fgv.Ide.Corporativohotsite.GenericResult;
using Fgv.Ide.Corporativohotsite.HotSite.Dto;
using Fgv.Ide.Corporativohotsite.HotSite.Interfaces;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using Fgv.Ide.Corporativohotsite.Dto;
using Fgv.Ide.Corporativohotsite.Interface;
using Fgv.Ide.Corporativohotsite.Storage;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Abp.Domain.Uow;
using Fgv.Ide.Corporativohotsite.HotSite.View;
using System.Dynamic;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using Fgv.Ide.Corporativohotsite.Configuration;
using Fgv.Ide.Corporativohotsite.Authorization;
using Fgv.Ide.Corporativohotsite.ObjetoValor;

namespace Fgv.Ide.Corporativohotsite.HotSite
{
    public class HotSiteInCompanyAppService : AbpServiceBase, IHotSiteInCompanyAppService
    {
        private readonly string _urlSiga2;
        private IOpcaoOfertaManager _opcaoOfertaManager;
        private IVwHotsiteHabilitacaoPreviaInscricaoManager _vwHotsiteHabilitacaoPreviaInscricaoManager;
        private IHotSiteInCompanyTurmaManager _hotSiteTurmaManager;
        private IHotSiteInCompanyConfiguracaoManager _hotSiteConfiguracaoManager;
        private IHotSiteInCompanyConfiguracaoPublicadoManager _hotSiteConfiguracaoPublicadoManager;
        private IHotSiteInCompanyMenuManager _hotSiteMenuManager;
        private IHotSiteInCompanyMenuPublicadoManager _hotSiteMenuPublicadoManager;
        private IHotSiteInCompanyCarrosselManager _hotSiteInCompanyCarrosselManager;
        private IHotSiteInCompanyCarrosselPublicadoManager _hotSiteInCompanyCarrosselPublicadoManager;
        private IHotSiteIncompanyManager _hotSiteIncompanyManager;
        private IHotSiteInCompanyMenuDocumentoManager _hotSiteInCompanyMenuDocumentoManager;
        private IHotSiteInCompanyMenuDocumentoPublicadoManager _hotSiteInCompanyMenuDocumentoPublicadoManager;
        private readonly IBinaryObjectManager _binaryObjectManager;
        private IHotSiteIncompanyAcessoManager _hotSiteIncompanyAcessoManager;
        private IHotSiteInCompanyGerenciarInscritosManager _hotSiteInCompanyGerenciarInscritosManager;
        private IInscricaoManager _inscricaoManager;
        private ISituacaoCandidatoManager _situacaoCandidatoManager;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IObjetoValorManager _objetoValorManager;
        private IHotSiteInCompanyTurmaComHabilitacaoManager _hotSiteInCompanyTurmaComHabilitacaoManager;


        public HotSiteInCompanyAppService(IAppConfigurationAccessor configuration,
                                          IOpcaoOfertaManager opcaoOfertaManager,
                                          IVwHotsiteHabilitacaoPreviaInscricaoManager vwHotsiteHabilitacaoPreviaInscricaoManager,
                                          IHotSiteInCompanyTurmaManager hotSiteTurmaManager,
                                          IHotSiteInCompanyConfiguracaoManager hotSiteConfiguracaoManager,
                                          IHotSiteInCompanyConfiguracaoPublicadoManager hotSiteConfiguracaoPublicadoManager,
                                          IHotSiteInCompanyMenuManager hotSiteMenuManager,
                                          IHotSiteInCompanyMenuPublicadoManager hotSiteMenuPublicadoManager,
                                          IHotSiteInCompanyCarrosselManager hotSiteInCompanyCarrosselManager,
                                          IHotSiteInCompanyCarrosselPublicadoManager hotSiteInCompanyCarrosselPublicadoManager,
                                          IHotSiteIncompanyManager hotSiteIncompanyManager,
                                          IHotSiteInCompanyMenuDocumentoManager hotSiteInCompanyMenuDocumentoManager,
                                          IHotSiteInCompanyMenuDocumentoPublicadoManager hotSiteInCompanyMenuDocumentoPublicadoManager,
                                          IBinaryObjectManager binaryObjectManager,
                                          IHotSiteIncompanyAcessoManager hotSiteIncompanyAcessoManager,
                                          IHotSiteInCompanyGerenciarInscritosManager hotSiteInCompanyGerenciarInscritosManager,
                                          IInscricaoManager inscricaoManager,
                                          ISituacaoCandidatoManager situacaoCandidatoManager,
                                          IObjetoValorManager objetoValorManager,
                                          IHotSiteInCompanyTurmaComHabilitacaoManager hotSiteInCompanyTurmaComHabilitacaoManager,
                                          IUnitOfWorkManager unitOfWorkManager)
        {
            _opcaoOfertaManager = opcaoOfertaManager;
            _vwHotsiteHabilitacaoPreviaInscricaoManager = vwHotsiteHabilitacaoPreviaInscricaoManager;
            _hotSiteTurmaManager = hotSiteTurmaManager;
            _hotSiteConfiguracaoManager = hotSiteConfiguracaoManager;
            _hotSiteConfiguracaoPublicadoManager = hotSiteConfiguracaoPublicadoManager;
            _hotSiteMenuManager = hotSiteMenuManager;
            _hotSiteMenuPublicadoManager = hotSiteMenuPublicadoManager;
            _hotSiteInCompanyCarrosselManager = hotSiteInCompanyCarrosselManager;
            _hotSiteInCompanyCarrosselPublicadoManager = hotSiteInCompanyCarrosselPublicadoManager;
            _hotSiteIncompanyManager = hotSiteIncompanyManager;
            _hotSiteInCompanyMenuDocumentoManager = hotSiteInCompanyMenuDocumentoManager;
            _hotSiteInCompanyMenuDocumentoPublicadoManager = hotSiteInCompanyMenuDocumentoPublicadoManager;
            _binaryObjectManager = binaryObjectManager;
            _hotSiteIncompanyAcessoManager = hotSiteIncompanyAcessoManager;
            _hotSiteInCompanyGerenciarInscritosManager = hotSiteInCompanyGerenciarInscritosManager;
            _inscricaoManager = inscricaoManager;
            _situacaoCandidatoManager = situacaoCandidatoManager;
            _objetoValorManager = objetoValorManager;
            _unitOfWorkManager = unitOfWorkManager;
            _hotSiteInCompanyTurmaComHabilitacaoManager = hotSiteInCompanyTurmaComHabilitacaoManager;
            _urlSiga2 = configuration.Configuration["Siga2:URLsWebPageBoundaries:Gestaovendas:Url"];
        }

        public async Task<OutputUploadBinaryObject> UploadBinaryObject(InputUploadBinaryObject input)
        {
            var file = new BinaryObject(null, input.Bytes);
            file.Id = Guid.NewGuid();

            await _binaryObjectManager.SaveAsync(file);

            return new OutputUploadBinaryObject()
            {
                Id = file.Id,
                TenantId = file.TenantId,
            };
        }

        public async Task<OutputDownloadObjectDto> DownloadBinaryObject(InputDownloadObjectDto input)
        {
            if (input == null || string.IsNullOrWhiteSpace(input.Token))
                return null;

            var binaryObject = await _binaryObjectManager.GetOrNullAsync(new System.Guid(input.Token));

            if (binaryObject == null)
            {
                return null;
            }

            return new OutputDownloadObjectDto { Bytes = binaryObject.Bytes };

        }

        public async Task<GenericVoid> RemoveBinaryObject(InputRemoveBinaryObjectDto input)
        {

            try
            {
                if (input == null || string.IsNullOrWhiteSpace(input.Token))
                    return null;

                await _binaryObjectManager.DeleteAsync(new System.Guid(input.Token));

                return new GenericVoid(true, string.Empty);

            }
            catch (Exception ex)
            {

                return new GenericVoid(false, ex.Message);
            }
        }

        public async Task<HotSiteInCompany> BuscarHotSiteInCompanyById(long id)
        {
            return await _hotSiteIncompanyManager.BuscarHotSitePorId(id);
        }

        public async Task<HotSiteInCompany> BuscarHotSiteInCompanyByNome(string nomeHotSite)
        {
            return await _hotSiteIncompanyManager.BuscarHotSitePorNome(nomeHotSite);
        }

        public async Task<GenericResultObject<List<HotSiteTurmaDto>>> BuscarTurmaPorIdHotSite(long idHotSite, string cpfPassaporte)
        {

            var hotSite = await _hotSiteIncompanyManager.BuscarHotSitePorId(idHotSite);
            GenericResultObject<List<HotSiteTurmaDto>> retorno = new GenericResultObject<List<HotSiteTurmaDto>>();

            retorno.Sucesso = true;

            if (hotSite == null)
            {
                throw new Exception("Hotsite não encontrado.");
            }

            if (hotSite.HabilitarPrevia && !string.IsNullOrEmpty(cpfPassaporte))
            {
                var listaTurma = await _hotSiteInCompanyTurmaComHabilitacaoManager.BuscarPorIdHotSite(cpfPassaporte.Replace(".","").Replace("-", ""), idHotSite);

                if (listaTurma == null || listaTurma.Count == 0) {
                    retorno.Sucesso = false;
                    retorno.Mensagem = "Candidato não está habilitado para esse hotsite.";
                }

                List<HotSiteTurmaDto> listaInscritos = ObjectMapper.Map<List<HotSiteTurmaDto>>(listaTurma);

                retorno.Item = listaInscritos;
            }
            else
            {
                var listaTurma = await _hotSiteTurmaManager.BuscarPorIdHotSite(idHotSite);

                List<HotSiteTurmaDto> listaInscritos = ObjectMapper.Map<List<HotSiteTurmaDto>>(listaTurma);

                retorno.Item = listaInscritos;
            }

            return retorno;
        }

        public async Task<HotSiteInCompanyConfiguracao> BuscarConfiguracaoPorIdHotSite(long idHotSite)
        {
            return await _hotSiteConfiguracaoManager.BuscarPorIdHotSite(idHotSite);
        }

        public async Task<HotSiteInCompanyConfiguracaoPublicado> BuscarConfiguracaoPublicadoPorIdHotSite(long idHotSite)
        {
            return await _hotSiteConfiguracaoPublicadoManager.BuscarPorIdHotSite(idHotSite);
        }

        public async Task<List<HotSiteInCompanyImagemCarrossel>> BuscarCarrosselPorIdHotSite(long idHotSite)
        {
            return await _hotSiteInCompanyCarrosselManager.BuscarPorIdHotSite(idHotSite);
        }

        public async Task<List<HotSiteInCompanyImagemCarrosselPublicado>> BuscarCarrosselPublicadoPorIdHotSite(long idHotSite)
        {
            return await _hotSiteInCompanyCarrosselPublicadoManager.BuscarPorIdHotSite(idHotSite);
        }

        public async Task<HotSiteInCompanyMenu> BuscarMenuPorId(long idMenu)
        {
            return await _hotSiteMenuManager.BuscarPorId(idMenu);
        }

        public async Task<List<InputBuscarMenuPorIdHotSite>> BuscarMenuPorIdHotSite(long idHotSite, bool usuarioLogado = false)
        {
            var result = await _hotSiteMenuManager.BuscarPorIdHotSite(idHotSite, usuarioLogado);

            return ObjectMapper.Map<List<InputBuscarMenuPorIdHotSite>>(result);
        }

        public async Task<HotSiteInCompanyMenuPublicado> BuscarMenuPublicadoPorId(long idMenu)
        {
            return await _hotSiteMenuPublicadoManager.BuscarPorId(idMenu);
        }

        public async Task<List<InputBuscarMenuPublicadoPorIdHotSite>> BuscarMenuPublicadoPorIdHotSite(long idHotSite, bool usuarioLogado = false)
        {
            var result = await _hotSiteMenuPublicadoManager.BuscarPorIdHotSite(idHotSite, usuarioLogado);

            return ObjectMapper.Map<List<InputBuscarMenuPublicadoPorIdHotSite>>(result);
        }

        public async Task<List<HotSiteInCompanyMenuDocumento>> BuscarMenuDocumentoPorIdMenu(long idMenu)
        {
            return await _hotSiteInCompanyMenuDocumentoManager.BuscarPorIdMenu(idMenu);
        }

        public async Task<HotSiteInCompanyMenuDocumento> BuscarMenuDocumentoPorToken(string token)
        {
            return await _hotSiteInCompanyMenuDocumentoManager.BuscarPorFileToken(token);
        }

        public async Task<List<HotSiteInCompanyMenuDocumentoPublicado>> BuscarMenuDocumentoPublicadoPorIdMenu(long idMenu)
        {
            return await _hotSiteInCompanyMenuDocumentoPublicadoManager.BuscarPorIdMenu(idMenu);
        }

        public async Task<HotSiteInCompanyMenuDocumentoPublicado> BuscarMenuDocumentoPublicadoPorToken(string token)
        {
            return await _hotSiteInCompanyMenuDocumentoPublicadoManager.BuscarPorFileToken(token);
        }

        public async Task<GenericResultObject<OutputInscrever>> Inscrever(InputInscrever input)
        {
            var pagina = string.Format("/ingresso/IdentificacaoSite.aspx");

            var _retorno = new OutputInscrever()
            {
                RedirectTo = string.Concat(_urlSiga2, pagina),
                IdOferta = 0,
                IdOpcaoOferta = 0,
            };

            var hotSite = await _hotSiteIncompanyManager.BuscarHotSitePorId(input.IdHotSiteInCompany);

            if (hotSite == null)
            {
                return new GenericResultObject<OutputInscrever>(_retorno, false, "Hotsite não encontrado.");
            }

            if (hotSite.HabilitarPrevia)
            {
                var previa = await _vwHotsiteHabilitacaoPreviaInscricaoManager.Buscar(input.CPF.Replace(".", "").Replace("-", ""), input.CodigoTurma);

                if (previa == null || !previa.Any())
                    return new GenericResultObject<OutputInscrever>(null, false, "O CPF informado não está habilitado para inscrever-se na turma escolhida.");

                var p = previa.FirstOrDefault();
                _retorno.IdOferta = p.IdOferta;
                _retorno.IdOpcaoOferta = p.IdOpcaoOferta;
                _retorno.NomeCandidato = p.NomeInscrito;
                _retorno.DDDTelefone = p.DDDCelular;
                _retorno.Telefone = p.Celular;
                _retorno.CPF = p.CPF;
                _retorno.Email = p.Email;
                _retorno.DataNascimento = p.DataNascimento.ToString("dd/MM/yyyy");
            }
            else
            {
                var op = await _opcaoOfertaManager.BuscarPorTurma(input.CodigoTurma);

                if (op == null)
                    return new GenericResultObject<OutputInscrever>(null, false, "Não existe opção de oferta para a turma informada.");

                _retorno.IdOferta = op.IdOferta;
                _retorno.IdOpcaoOferta = op.Id;
            }

            return new GenericResultObject<OutputInscrever>(_retorno);
        }

        #region "Login"
        //public async Task<GenericVoid> VerificarLogin(string email, string senha, long idHotSite, string nomeHotSite)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(email) || String.IsNullOrEmpty(senha)) throw new UserFriendlyException("Informe o e-mail e a senha.");


        //        string senhaDecodificada = DecodeFrom64(senha);
        //        CriarMD5 md5 = new CriarMD5();
        //        var senhaMD5 = md5.RetornarMD5(senhaDecodificada);

        //        var permitirAcesso = await _hotSiteIncompanyAcessoManager.ValidarLogin(email, senhaMD5);
        //        if (!permitirAcesso) throw new UserFriendlyException("Não foi possível fazer login com os dados informados.Tente novamente.");
        //    }
        //    catch (UserFriendlyException ex)
        //    {
        //        return new GenericVoid(false, ex.Message.ToString());
        //    }

        //    return new GenericVoid(true, string.Empty);

        //}

        public async Task<GenericVoid> VerificarLogin(string email, string senha, long idHotSite, string nomeHotSite)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || String.IsNullOrEmpty(senha)) throw new UserFriendlyException("Informe o e-mail e a senha.");

                string senhaDecodificada = DecodeFrom64(senha);

                string _hashCalculado;

                _hashCalculado = Hash.GenerateSHA256String(senhaDecodificada).ToUpper();

                var permitirAcesso = await _hotSiteIncompanyAcessoManager.ValidarLogin(email, _hashCalculado);
                if (!permitirAcesso) throw new UserFriendlyException("Não foi possível fazer login com os dados informados.Tente novamente.");
            }
            catch (UserFriendlyException ex)
            {
                return new GenericVoid(false, ex.Message.ToString());
            }

            return new GenericVoid(true, string.Empty);

        }

        public async Task<HotSiteIncompanyLogin> BuscarLoginPorEmail(string email)
        {
            return await this._hotSiteIncompanyAcessoManager.BuscarPorEmail(email);
        }

        private string DecodeFrom64(string dados)
        {
            try
            {
                byte[] dadosAsBytes = System.Convert.FromBase64String(dados);
                string resultado = System.Text.ASCIIEncoding.ASCII.GetString(dadosAsBytes);
                return resultado;
            }
            catch (UserFriendlyException ex)
            {
                throw ex;
            }
        }
        #endregion

        #region "Gerenciar Inscritos"
        public async Task<List<HotSiteInscritosDto>> BuscarInscritosPorTurma(string codigoTurma)
        {
            if (String.IsNullOrEmpty(codigoTurma)) { throw new UserFriendlyException("É necessário informar o código da turma."); }

            var infoInscritosPorTurma = await this._hotSiteInCompanyGerenciarInscritosManager.BuscarInscritosPorCodigoTurma(codigoTurma);
            var hotsiteInscritosDto = ObjectMapper.Map<List<HotSiteInscritosDto>>(infoInscritosPorTurma);
            return hotsiteInscritosDto;
        }
        public async Task<List<HotSiteInscritosDto>> BuscarInscritosPorHotSite(long idHotSite)
        {
            if (idHotSite == 0) { throw new UserFriendlyException("É necessário informar o idHotSite."); }

            var infoInscritosPorHotSite = await this._hotSiteInCompanyGerenciarInscritosManager.BuscarInscritosPorHotSite(idHotSite);
            var hotsiteInscritosDto = ObjectMapper.Map<List<HotSiteInscritosDto>>(infoInscritosPorHotSite);
            return hotsiteInscritosDto;
        }

        public async Task<GenericResultObject<string>> HabilitarInscritos(InputInscricaoHabilitarDto _input)
        {

            try
            {
                if (_input.Inscritos == null || _input.Inscritos.Count == 0)
                {
                    throw new UserFriendlyException("Não foram informados inscritos.");
                }

                var checkCPF = _input.Inscritos.Find(x => x.Cpf.Trim().Length == 0 || x.Cpf == null);
                var checkIdOferta = _input.Inscritos.Find(x => x.IdOferta == 0);
                var checkIdOpcaoOferta = _input.Inscritos.Find(x => x.IdOpcaoOferta == 0);


                if (checkCPF != null || checkIdOferta != null || checkIdOpcaoOferta != null)
                {
                    throw new UserFriendlyException("Verifique se todos os inscritos possuem CPF, Oferta e Opção de Oferta.");
                }
                var _lstInscricao = ObjectMapper.Map<List<InputInscricao>>(_input.Inscritos);

                var _situacaoCandidato = await this._situacaoCandidatoManager.BuscarSituacaoCandidatoPorDescricao("Habilitado");
                if (_situacaoCandidato == null) { throw new UserFriendlyException("Não foi possível encontrar a nova situação do candidato - Habilitado."); }

                _lstInscricao.ToList().ForEach(i => i.NovoIdSituacaoCandidato = _situacaoCandidato.Id);

                await this._inscricaoManager.MudarSituacaoInscricaoCandidato(_lstInscricao);

            }
            catch (Exception ex)
            {
                return new GenericResultObject<string>(string.Empty, false, ex.Message.ToString());
            }

            return new GenericResultObject<string>("Situação Candidato Alterada", true, string.Empty);
        }


        public async Task<GenericResultObject<string>> MudarSituacaoCandidato(InscricaoDto _input)
        {

            try
            {
                if (_input == null)
                {
                    throw new UserFriendlyException("É necessário informar os dados de inscrição.");
                }


                if (String.IsNullOrEmpty(_input.Cpf) || (_input.IdOferta == 0) || (_input.IdOpcaoOferta == 0))
                {
                    throw new UserFriendlyException("Verifique se o inscrito possue CPF, Oferta e Opção de Oferta.");
                }

                var _inscricao = ObjectMapper.Map<InputInscricao>(_input);

                var _situacaoCandidato = await this._situacaoCandidatoManager.BuscarSituacaoCandidatoPorDescricao(_inscricao.NovaSituacaoCandidato);
                if (_situacaoCandidato == null) { throw new UserFriendlyException("Não foi possível encontrar a nova situação do candidato - ." + _inscricao.NovaSituacaoCandidato); }

                _inscricao.NovoIdSituacaoCandidato = _situacaoCandidato.Id;

                await this._inscricaoManager.MudarSituacaoInscricaoCandidato(_inscricao);

            }
            catch (Exception ex)
            {
                return new GenericResultObject<string>(string.Empty, false, ex.Message.ToString());
            }

            return new GenericResultObject<string>("Situação Candidato Alterada", true, string.Empty);
        }
        #endregion



        //public async Task<GenericResultObject<string>> RedefinirSenhaDeAcesso(long idHotsite, string email, string senha)
        //{

        //    HotSiteIncompanyLogin user;

        //    try
        //    {

        //        user = await this._hotSiteIncompanyAcessoManager.Buscar(new HotSiteIncompanyLogin { IdHotSiteIncompany = idHotsite, Email = email });

        //        if (user == null)
        //        {
        //            throw new Exception("E-mail não localizado!");
        //        }


        //        CriarMD5 md5 = new CriarMD5();
        //        var senhaMD5 = md5.RetornarMD5(senha);
        //        user.Senha = senhaMD5;
        //        await this._hotSiteIncompanyAcessoManager.Alterar(user);

        //    }
        //    catch (Exception ex)
        //    {
        //        return new GenericResultObject<string>(string.Empty, false, ex.Message.ToString());
        //    }

        //    return new GenericResultObject<string>(user.HotSiteInCompany.NomeHotSite, true, string.Empty);
        //}

        public async Task<GenericResultObject<string>> RedefinirSenhaDeAcesso(long idHotsite, string email, string senha)
        {

            HotSiteIncompanyLogin user;

            try
            {

                user = await this._hotSiteIncompanyAcessoManager.Buscar(new HotSiteIncompanyLogin { IdHotSiteIncompany = idHotsite, Email = email });

                if (user == null)
                {
                    throw new Exception("E-mail não localizado!");
                }

                string _hashCalculado;

                _hashCalculado = Hash.GenerateSHA256String(senha).ToUpper();

                user.Senha = _hashCalculado;

                await this._hotSiteIncompanyAcessoManager.Alterar(user);

            }
            catch (Exception ex)
            {
                return new GenericResultObject<string>(string.Empty, false, ex.Message.ToString());
            }

            return new GenericResultObject<string>(user.HotSiteInCompany.NomeHotSite, true, string.Empty);
        }

        public async Task<GenericResultObject<string>> RedirecionarGerenciarInscritos(InputHotSiteSSOGerenciarInscritoDto input)
        {
            string _urlSSOGerenciarInscritos = "";
            try
            {
                string urlHotSite = await this.BuscarUrlHotSite();
                string nomeHotSite = input.NomeHotSite + "/gerenciar-inscritos" + "?Token=";
                string _token = LogInManagerExtensions.CreateTokenGerenciarInscritosHotSite(input.Usuario, input.NomeHotSite);

                _urlSSOGerenciarInscritos = urlHotSite + nomeHotSite + _token;


            }
            catch (UserFriendlyException ex)
            {
                return new GenericResultObject<string>("", false, ex.Message.ToString());
            }
            return new GenericResultObject<string>(_urlSSOGerenciarInscritos, true, string.Empty);
        }

        private async Task<string> BuscarUrlHotSite()
        {
            return await this._objetoValorManager.BuscarUrlHotSite();
        }
    }


    //public class CriarMD5
    //{
    //    public string RetornarMD5(string Senha)
    //    {
    //        using (MD5 md5Hash = MD5.Create())
    //        {
    //            return RetonarHash(md5Hash, Senha);
    //        }
    //    }

    //    public bool ComparaMD5(string senhabanco, string Senha_MD5)
    //    {
    //        using (MD5 md5Hash = MD5.Create())
    //        {
    //            var senha = RetornarMD5(senhabanco);
    //            if (VerificarHash(md5Hash, Senha_MD5, senha))
    //            {
    //                return true;
    //            }
    //            else
    //            {
    //                return false;
    //            }
    //        }
    //    }

    //    private string RetonarHash(MD5 md5Hash, string input)
    //    {
    //        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

    //        StringBuilder sBuilder = new StringBuilder();

    //        for (int i = 0; i < data.Length; i++)
    //        {
    //            sBuilder.Append(data[i].ToString("x2"));
    //        }

    //        return sBuilder.ToString();
    //    }

    //    private bool VerificarHash(MD5 md5Hash, string input, string hash)
    //    {
    //        StringComparer compara = StringComparer.OrdinalIgnoreCase;

    //        if (0 == compara.Compare(input, hash))
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }


    //}

    public class Hash
    {
        public static string GenerateSHA256String(String inputString)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha256.ComputeHash(bytes);
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i <= hash.Length - 1; i++)
                stringBuilder.Append(hash[i].ToString("X2"));
            return stringBuilder.ToString();
        }
    }


}
