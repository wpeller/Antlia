using System.Linq;
using Abp.Configuration;
using Abp.Localization;
using Abp.Net.Mail;
using Microsoft.EntityFrameworkCore;
using Fgv.Ide.Corporativohotsite.EntityFrameworkCore;

namespace Fgv.Ide.Corporativohotsite.Migrations.Seed.Host
{
    public class DefaultSettingsCreator
    {
        private readonly CorporativohotsiteDbContext _context;

        public DefaultSettingsCreator(CorporativohotsiteDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            //Emailing
            AddSettingIfNotExists(EmailSettingNames.DefaultFromAddress, "admin@fgv.br");
            AddSettingIfNotExists(EmailSettingNames.DefaultFromDisplayName, "fgv.br mailer");

            //Languages
            AddSettingIfNotExists(LocalizationSettingNames.DefaultLanguage, "pt-BR");
        }

        private void AddSettingIfNotExists(string name, string value, int? tenantId = null)
        {
            if (_context.Settings.IgnoreQueryFilters().Any(s => s.Name == name && s.TenantId == tenantId && s.UserId == null))
            {
                return;
            }

            _context.Settings.Add(new Setting(tenantId, null, name, value));
            _context.SaveChanges();
        }
    }
}