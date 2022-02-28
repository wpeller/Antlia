using Abp.Domain.Repositories;
using Fgv.Ide.Corporativohotsite.ObjetoValor;
using Fgv.Ide.Corporativohotsite.ObjetoValor.Table;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite
{
    public class ObjetoValorManager : IObjetoValorManager
    {

        private readonly IRepository<ObjValor, long> _repository;

        public ObjetoValorManager(IRepository<ObjValor, long> repository)
        {
            this._repository = repository;

        }
        public async Task<string> BuscarUrlHotSite()
        {
            var obj = await this._repository.GetAll().Where(x => x.Discriminator == "UrlHotSiteIncompany").FirstOrDefaultAsync();
            return obj.Valor;
        }

        public async Task<string> BuscarUrlRedefinicaoHotSite()
        {
            var obj = await this._repository.GetAll().Where(x => x.Discriminator == "UrlRedefinicaoHotSite").FirstOrDefaultAsync();
            return obj.Valor;
        }

        public async Task<string> BuscarUrlPainelHotSite()
        {
            var obj = await this._repository.GetAll().Where(x => x.Discriminator == "UrlPainelHotSite").FirstOrDefaultAsync();
            return obj.Valor;
        }
    }
}
