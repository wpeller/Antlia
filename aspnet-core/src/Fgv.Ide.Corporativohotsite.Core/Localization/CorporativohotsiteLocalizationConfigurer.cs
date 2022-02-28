using System.Reflection;
using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Fgv.Ide.Corporativohotsite.Localization
{
    public static class CorporativohotsiteLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    CorporativohotsiteConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(CorporativohotsiteLocalizationConfigurer).GetAssembly(),
                        "Fgv.Ide.Corporativohotsite.Localization.Corporativohotsite"
                    )
                )
            );
        }
    }
}