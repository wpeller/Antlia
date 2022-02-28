using Abp.Dependency;
using Fgv.Ide.Corporativohotsite.HotSite.Table;
using Fgv.Ide.Corporativohotsite.HotSite.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.HotSite.Interfaces
{
    public interface IHotSiteInCompanyGerenciarInscritosManager : ITransientDependency
    {
        Task<List<InfoGerenciarInscritosHotSiteIncompany>> BuscarInscritosPorCodigoTurma(string codigoTurma);
        Task<List<InfoGerenciarInscritosHotSiteIncompany>> BuscarInscritosPorHotSite(long idHotSite);

        Task<List<InfoGerenciarInscritosHotSiteIncompany>> BuscarInscritosPorProjeto(long idProjeto);
        //Task<List<InfoGerenciarInscritosHotSiteIncompany>> HabilitarInscricao(List<>);
    }
}
