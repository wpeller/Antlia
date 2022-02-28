using Abp.Auditing;
using Fgv.Ide.Corporativohotsite.Web.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace Fgv.Ide.Corporativohotsite.Web.Controllers
{
    public class HomeController : CorporativohotsiteControllerBase
    {
        private readonly AppConfigurationAccessor _configurationAccessor;

        public HomeController(AppConfigurationAccessor configurationAccessor)
        {
            _configurationAccessor = configurationAccessor;
        }

        [DisableAuditing]
        public IActionResult Index()
        {
            var serverRootAddress = _configurationAccessor.Configuration["App:ServerRootAddress"];

            return Redirect($"{serverRootAddress}swagger");
        }
    }
}
