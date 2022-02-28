using Abp;
using Fgv.Ide.Corporativohotsite.GenericResult;
using MovimentosManuais.ApplicationCore;
using MovimentosManuais.ApplicationCore.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite
{
    public class MovimentoServicoAppService : AbpServiceBase, IMovimentoAppService
    {

        private IMovimentoManager _movimentoManager;


        public MovimentoServicoAppService(IMovimentoManager produtoManager)
        {
            _movimentoManager = produtoManager;

        }


        public async Task<List<Movimento_ManualResultDto>> BuscarTodos()
        {

            List < Movimento_Manual > retorno = await  this._movimentoManager.BuscarTodos();

            List<Movimento_ManualResultDto> movimentoDto = ObjectMapper.Map<List<Movimento_ManualResultDto>>(retorno);

            return movimentoDto;
        }



        public async Task<GenericVoid> Gravar(Movimento_ManualDto movimentoDto)
        {
            GenericVoid retorno = new GenericVoid();
            Movimento_Manual movimento;

            if (movimentoDto.VAL_VALOR == 0) {
                retorno.Mensagem = "Valor não informado.";
                retorno.Sucesso = false;
                return retorno;
            }

            movimento = ObjectMapper.Map<Movimento_Manual>(movimentoDto);

            this._movimentoManager.Gravar(movimento);

            retorno.Mensagem = "Salvo com sucesso.";
            retorno.Sucesso = true;

            return retorno;
        }
    }


}
