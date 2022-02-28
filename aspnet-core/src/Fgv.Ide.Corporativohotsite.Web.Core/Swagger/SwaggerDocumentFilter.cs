using Abp.Authorization;
using Abp.Dependency;
using Abp.Runtime.Session;
using Fgv.Ide.Corporativohotsite.Authorization;
using Fgv.Ide.Corporativohotsite.Authorization.Users;
using Microsoft.AspNetCore.Identity;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Fgv.Ide.Corporativohotsite.Web.Swagger
{
    public class SwaggerDocumentFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            if (IocManager.Instance.Resolve<IPermissionChecker>().IsGranted(AppPermissions.Pages_Administration_Swagger))
                return;

            foreach (var pathItem in swaggerDoc.Paths.Values)
            {
                pathItem.Delete = null;
                pathItem.Patch = null;
                pathItem.Post = null;
                pathItem.Put = null;
                pathItem.Get = null;
            }

            swaggerDoc.Definitions.Clear();
        }
    }
}