using Abp.Domain.Services;

namespace Fgv.Ide.Corporativohotsite
{
    public abstract class CorporativohotsiteDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected CorporativohotsiteDomainServiceBase()
        {
            LocalizationSourceName = CorporativohotsiteConsts.LocalizationSourceName;
        }
    }
}
