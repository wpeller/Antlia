using Abp.Dependency;
using MovimentosManuais.ApplicationCore;
using MovimentosManuais.ApplicationCore.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite
{
    public interface IMovimentoManager : ITransientDependency
    {
        Task<List<Movimento_Manual>> BuscarTodos();
        void Gravar(Movimento_Manual movimento);
    }
}