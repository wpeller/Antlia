using Abp;

namespace Fgv.Ide.Corporativohotsite
{
    /// <summary>
    /// This class can be used as a base class for services in this application.
    /// It has some useful objects property-injected and has some basic methods most of services may need to.
    /// It's suitable for non domain nor application service classes.
    /// For domain services inherit <see cref="CorporativohotsiteDomainServiceBase"/>.
    /// For application services inherit CorporativohotsiteAppServiceBase.
    /// </summary>
    public abstract class CorporativohotsiteServiceBase : AbpServiceBase
    {
        protected CorporativohotsiteServiceBase()
        {
            LocalizationSourceName = CorporativohotsiteConsts.LocalizationSourceName;
        }
    }
}