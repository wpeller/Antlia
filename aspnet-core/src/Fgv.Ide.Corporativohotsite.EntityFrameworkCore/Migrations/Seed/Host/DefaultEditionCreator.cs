using System.Linq;
using Abp.Application.Features;
using Microsoft.EntityFrameworkCore;
using Fgv.Ide.Corporativohotsite.Editions;
using Fgv.Ide.Corporativohotsite.EntityFrameworkCore;
using Fgv.Ide.Corporativohotsite.Features;

namespace Fgv.Ide.Corporativohotsite.Migrations.Seed.Host
{
    public class DefaultEditionCreator
    {
        private readonly CorporativohotsiteDbContext _context;

        public DefaultEditionCreator(CorporativohotsiteDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateEditions();
        }

        private void CreateEditions()
        {
            var defaultEdition = _context.Editions.IgnoreQueryFilters().FirstOrDefault(e => e.Name == EditionManager.DefaultEditionName);
            if (defaultEdition == null)
            {
                defaultEdition = new SubscribableEdition { Name = EditionManager.DefaultEditionName, DisplayName = EditionManager.DefaultEditionName };
                _context.Editions.Add(defaultEdition);
                _context.SaveChanges();

                /* Add desired features to the standard edition, if wanted... */
            }
        }

        private void CreateFeatureIfNotExists(int editionId, string featureName, bool isEnabled)
        {
            var defaultEditionChatFeature = _context.EditionFeatureSettings.IgnoreQueryFilters()
                                                        .FirstOrDefault(ef => ef.EditionId == editionId && ef.Name == featureName);

            if (defaultEditionChatFeature == null)
            {
                _context.EditionFeatureSettings.Add(new EditionFeatureSetting
                {
                    Name = featureName,
                    Value = isEnabled.ToString().ToLower(),
                    EditionId = editionId
                });
            }
        }
    }
}