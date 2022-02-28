using Microsoft.AspNetCore.Antiforgery;

namespace Fgv.Ide.Corporativohotsite.Web.Controllers
{
    public class AntiForgeryController : CorporativohotsiteControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
