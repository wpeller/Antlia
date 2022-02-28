using Abp.Dependency;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite.Interfaces
{
    public interface IHotSiteIncompanyAcessoManager : ITransientDependency
    {
        Task<HotSiteIncompanyLogin> Buscar(HotSiteIncompanyLogin acesso);
        Task<HotSiteIncompanyLogin> BuscarPorEmail(string email);
        Task<bool> ValidarLogin(string email, string password);
        Task<HotSiteIncompanyLogin> Alterar(HotSiteIncompanyLogin loginHotsite);
    }
}
