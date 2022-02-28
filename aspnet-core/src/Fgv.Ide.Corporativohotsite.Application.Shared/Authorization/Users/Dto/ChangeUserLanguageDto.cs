using System.ComponentModel.DataAnnotations;

namespace Fgv.Ide.Corporativohotsite.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
