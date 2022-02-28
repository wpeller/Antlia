using System.Threading.Tasks;
using Abp.Net.Mail;
using Fgv.Ide.Corporativohotsite.Configuration.Host.Dto;

namespace Fgv.Ide.Corporativohotsite.Configuration
{
    public abstract class SettingsAppServiceBase : CorporativohotsiteAppServiceBase
    {
        private readonly IEmailSender _emailSender;

        protected SettingsAppServiceBase(
            IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        #region Send Test Email

        public async Task SendTestEmail(SendTestEmailInput input)
        {
            await _emailSender.SendAsync(
                input.EmailAddress,
                L("TestEmail_Subject"),
                L("TestEmail_Body")
            );
        }

        #endregion
    }
}
