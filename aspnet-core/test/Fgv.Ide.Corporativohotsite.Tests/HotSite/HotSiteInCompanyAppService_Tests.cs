using Abp.UI;
using Fgv.Ide.Corporativohotsite.Dto;
using Fgv.Ide.Corporativohotsite.HotSite;
using Fgv.Ide.Corporativohotsite.HotSite.Dto;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using Fgv.Ide.Corporativohotsite.Tests.AcessoExterno.Boundaries;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Fgv.Ide.Corporativohotsite.Tests.HotSite
{
    public class HotSiteInCompanyAppService_Tests : AppTestBaseSiga2
    {
        private readonly IHotSiteInCompanyAppService _hotsiteAppService;

        static long idHotSiteInCompany { get; set; }

        public HotSiteInCompanyAppService_Tests()
        {
            _hotsiteAppService = Resolve<IHotSiteInCompanyAppService>();
        }

        #region "Testes GERENCIAR INSCRITOS"
        [FactCustom]
        public async Task devo_listar_candidatos_por_hotsite_com_sucesso()
        {
            idHotSiteInCompany = await BuscarIdHotSiteInCompany();

            if (idHotSiteInCompany <= 0)
            {
                var exception = await Assert.ThrowsAsync<UserFriendlyException>(() => _hotsiteAppService.BuscarInscritosPorHotSite(default(long)));
                Assert.Equal("É necessário informar o idHotSite.", exception.Message);
            }
            else
            {
                var output = await _hotsiteAppService.BuscarInscritosPorHotSite(idHotSiteInCompany);

                output.Count().ShouldNotBeNull();
            }
        }

        [FactCustom]
        public async Task devo_listar_candidatos_por_hotsite_semidhotsite_Teste_Negativo()
        {
            var exception = await Assert.ThrowsAsync<UserFriendlyException>(() => _hotsiteAppService.BuscarInscritosPorHotSite(0));
            Assert.Equal("É necessário informar o idHotSite.", exception.Message);
        }

        [FactCustom]
        public async Task devo_buscar_inscritos_por_turma_com_sucesso()
        {
            var turma = await BuscarTurma();

            if (turma == null)
            {
                var exception = await Assert.ThrowsAsync<UserFriendlyException>(() => _hotsiteAppService.BuscarInscritosPorTurma(default(string)));
                Assert.Equal("É necessário informar o código da turma.", exception.Message);
            }
            else
            {
                var output = await _hotsiteAppService.BuscarInscritosPorTurma(turma.CodigoTurma);

                output.Count().ShouldNotBeNull();
            }
        }

        [FactCustom]
        public async Task devo_buscar_inscritos_por_turma_semcodigoturma_Teste_Negativo()
        {
            var exception = await Assert.ThrowsAsync<UserFriendlyException>(() => _hotsiteAppService.BuscarInscritosPorTurma(""));
            Assert.Equal("É necessário informar o código da turma.", exception.Message);
        }

        [FactCustom]
        public async Task devo_mudar_situacao_candidato_pendente_para_habilitado_com_sucesso()
        {
            var lstPendentes = await BuscarCandidatoPendente();

            InputInscricaoHabilitarDto _input = new InputInscricaoHabilitarDto
            {
                Inscritos = new List<InscricaoDto>()
            };
            _input.Inscritos = lstPendentes;

            var output = await _hotsiteAppService.HabilitarInscritos(_input);

            if (lstPendentes == null || !lstPendentes.Any())
                Assert.False(output.Sucesso);
            else
                output.Sucesso.ShouldBeTrue();
        }

        [FactCustom]
        public async Task devo_mudar_situacao_candidato_pendente_para_habilitado_seminscritos_Teste_Negativo()
        {
            InputInscricaoHabilitarDto _input = new InputInscricaoHabilitarDto();
            var output = await _hotsiteAppService.HabilitarInscritos(_input);
            output.Mensagem.ShouldBe("Não foram informados inscritos.");
        }

        private async Task<long> BuscarIdHotSiteInCompany()
        {
            for (int i = 1; i <= 100; i++)
            {
                var hs = await _hotsiteAppService.BuscarHotSiteInCompanyById(i);

                if (hs != null && hs.Id != 0)
                {
                    return hs.Id;
                }
            }

            return 0;
        }

        private async Task<HotSiteTurmaDto> BuscarTurma()
        {
            var idHotSite = await BuscarIdHotSiteInCompany();
            var turma = await _hotsiteAppService.BuscarTurmaPorIdHotSite(idHotSite,null);

            if (turma != null && turma.Item.Any())
            {
                var rndTurma = new Random();
                int indiceTurma = rndTurma.Next(0, turma.Item.Count - 1);
                return turma.Item[indiceTurma];
            }

            return null;
        }

        private async Task<List<InscricaoDto>> BuscarCandidatoPendente()
        {
            idHotSiteInCompany = await BuscarIdHotSiteInCompany();

            if (idHotSiteInCompany <= 0)
            {
                var exception = await Assert.ThrowsAsync<UserFriendlyException>(() => _hotsiteAppService.BuscarInscritosPorHotSite(default(long)));
                Assert.Equal("É necessário informar o idHotSite.", exception.Message);
            }
            else
            {
                var _inscritos = await _hotsiteAppService.BuscarInscritosPorHotSite(idHotSiteInCompany);

                if (_inscritos != null && _inscritos.Any())
                {
                    return _inscritos.Where(x => x.SituacaoCandidato == "Pendente")
                         .Select(candidato =>
                         {
                             return new InscricaoDto
                             {
                                 NomeInscrito = candidato.NomeInscrito,
                                 Cpf = candidato.CPF,
                                 IdSituacaoCandidato = candidato.IdSituacaoCandidato,
                                 IdOferta = candidato.IdOFerta,
                                 IdOpcaoOferta = candidato.IdOpcaoOferta,
                                 NovaSituacaoCandidato = "Habilitado"
                             };
                         })
                         .ToList();
                }
            }

            return new List<InscricaoDto>();
        }

        #endregion

        [FactCustom]
        public async Task Test_BinaryObject_Upload_Download()
        {
            var _bytes = Encoding.UTF8.GetBytes("teste");

            var inputUpload = new InputUploadBinaryObject()
            {
                Bytes = _bytes
            };

            var resultUpload = await _hotsiteAppService.UploadBinaryObject(inputUpload);

            Assert.True(resultUpload != null && resultUpload.Id != null && resultUpload.Id != default(Guid));

            var inputDownload = new InputDownloadObjectDto()
            {
                Token = resultUpload.Id.ToString()
            };

            var resultDownload = await _hotsiteAppService.DownloadBinaryObject(inputDownload);

            Assert.True(resultDownload != null && resultDownload.Bytes != null && resultDownload.Bytes.Length > 0);
        }

        [FactCustom]
        public async Task Test_BuscarHotSiteInCompanyById()
        {
            var result = await _hotsiteAppService.BuscarHotSiteInCompanyById(0);

            Assert.True(result == null);
        }

        [FactCustom]
        public async Task Test_BuscarHotSiteInCompanyByNome()
        {
            var result = await _hotsiteAppService.BuscarHotSiteInCompanyByNome("");

            Assert.True(result == null);
        }

        [FactCustom]
        public async Task Test_BuscarTurmaPorIdHotSite()
        {
            var result = await _hotsiteAppService.BuscarTurmaPorIdHotSite(0,null);

            Assert.True(result != null && result.Item.Count == 0);
        }

        [FactCustom]
        public async Task Test_BuscarConfiguracaoPorIdHotSite()
        {
            var result = await _hotsiteAppService.BuscarConfiguracaoPorIdHotSite(0);

            Assert.True(result == null);
        }

        [FactCustom]
        public async Task Test_BuscarConfiguracaoPublicadoPorIdHotSite()
        {
            var result = await _hotsiteAppService.BuscarConfiguracaoPublicadoPorIdHotSite(0);

            Assert.True(result == null);
        }

        [FactCustom]
        public async Task Test_BuscarCarrosselPorIdHotSite()
        {
            var result = await _hotsiteAppService.BuscarCarrosselPorIdHotSite(0);

            Assert.True(result != null && result.Count == 0);
        }

        [FactCustom]
        public async Task Test_BuscarCarrosselPublicadoPorIdHotSite()
        {
            var result = await _hotsiteAppService.BuscarCarrosselPublicadoPorIdHotSite(0);

            Assert.True(result != null && result.Count == 0);
        }

        [FactCustom]
        public async Task Test_BuscarMenuPorId()
        {
            var result = await _hotsiteAppService.BuscarMenuPorId(0);

            Assert.True(result == null);
        }

        [FactCustom]
        public async Task Test_BuscarMenuPorIdHotSite()
        {
            var result = await _hotsiteAppService.BuscarMenuPorIdHotSite(0);

            Assert.True(result != null && result.Count == 0);
        }

        [FactCustom]
        public async Task Test_BuscarMenuPublicadoPorId()
        {
            var result = await _hotsiteAppService.BuscarMenuPublicadoPorId(0);

            Assert.True(result == null);
        }

        [FactCustom]
        public async Task Test_BuscarMenuPublicadoPorIdHotSite()
        {
            var result = await _hotsiteAppService.BuscarMenuPublicadoPorIdHotSite(0);

            Assert.True(result != null && result.Count == 0);
        }

        [FactCustom]
        public async Task Test_BuscarMenuDocumentoPorIdMenu()
        {
            var result = await _hotsiteAppService.BuscarMenuDocumentoPorIdMenu(0);

            Assert.True(result != null && result.Count == 0);
        }

        [FactCustom]
        public async Task Test_BuscarMenuDocumentoPorToken()
        {
            var result = await _hotsiteAppService.BuscarMenuDocumentoPorToken("");

            Assert.True(result == null);
        }

        [FactCustom]
        public async Task Test_BuscarMenuDocumentoPublicadoPorIdMenu()
        {
            var result = await _hotsiteAppService.BuscarMenuDocumentoPublicadoPorIdMenu(0);

            Assert.True(result != null && result.Count == 0);
        }

        [FactCustom]
        public async Task Test_BuscarMenuDocumentoPublicadoPorToken()
        {
            var result = await _hotsiteAppService.BuscarMenuDocumentoPublicadoPorToken("");

            Assert.True(result == null);
        }

        [FactCustom]
        public async Task Test_Inscrever()
        {
            var input = new InputInscrever()
            {
                CodigoTurma = "",
                CPF = "",
                Email = "",
                IdHotSiteInCompany = 0,
            };

            var result = await _hotsiteAppService.Inscrever(input);

            Assert.True(result != null);
            Assert.True(!result.Sucesso);
            Assert.True(result.Item != null);
        }
    }
}
