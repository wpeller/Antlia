using Abp.Dependency;
using Fgv.Ide.Corporativohotsite.Dto;
using Fgv.Ide.Corporativohotsite.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.Interface
{
    public interface IInscricaoManager : ITransientDependency
    {
        Task<bool> MudarSituacaoInscricaoCandidato(List<InputInscricao> _lstInscricao);

        Task<bool> MudarSituacaoInscricaoCandidato(InputInscricao _inscricao);
        Task<Inscricao> BuscarInscricaoPorCPFIdOfertaIdOpcaoOferta(string cpf, long idOferta, long idOpcaoOferta);

    }
}
