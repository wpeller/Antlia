using Abp.Configuration;
using Abp.Net.Mail;
using Abp.Net.Mail.Smtp;
using Abp.Runtime.Security;

namespace Fgv.Ide.Corporativohotsite.Emailing
{
    public class CorporativohotsiteSmtpEmailSenderConfiguration : SmtpEmailSenderConfiguration
    {
        public CorporativohotsiteSmtpEmailSenderConfiguration(ISettingManager settingManager) : base(settingManager)
        {

        }

        public override string Password => SimpleStringCipher.Instance.Decrypt(GetNotEmptySettingValue(EmailSettingNames.Smtp.Password));
    }
}