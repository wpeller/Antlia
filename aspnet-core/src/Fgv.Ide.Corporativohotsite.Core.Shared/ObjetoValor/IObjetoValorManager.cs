using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.ObjetoValor
{
    public interface IObjetoValorManager : ITransientDependency
    {
        Task<string> BuscarUrlHotSite();
        Task<string> BuscarUrlRedefinicaoHotSite();
        Task<string> BuscarUrlPainelHotSite();
    }
}
