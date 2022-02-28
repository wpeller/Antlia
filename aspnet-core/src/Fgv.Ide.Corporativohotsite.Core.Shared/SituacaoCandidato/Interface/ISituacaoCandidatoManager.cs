using Abp.Dependency;
using Fgv.Ide.Corporativohotsite.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.Interface
{
    public interface ISituacaoCandidatoManager : ITransientDependency
    {
        Task<SituacaoCandidato> BuscarSituacaoCandidatoPorDescricao(string _descricaoSituacaoCandidato);        
    }
}
