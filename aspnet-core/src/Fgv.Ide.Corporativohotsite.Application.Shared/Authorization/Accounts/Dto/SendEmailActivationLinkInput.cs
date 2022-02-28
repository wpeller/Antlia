using System.ComponentModel.DataAnnotations;

namespace Fgv.Ide.Corporativohotsite.Authorization.Accounts.Dto
{
    public class SendEmailActivationLinkInput
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}