using Abp.AspNetCore.Mvc.Authorization;
using Fgv.Ide.Corporativohotsite.Storage;

namespace Fgv.Ide.Corporativohotsite.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ProfileController : ProfileControllerBase
    {
        public ProfileController(ITempFileCacheManager tempFileCacheManager) :
            base(tempFileCacheManager)
        {
        }
    }
}