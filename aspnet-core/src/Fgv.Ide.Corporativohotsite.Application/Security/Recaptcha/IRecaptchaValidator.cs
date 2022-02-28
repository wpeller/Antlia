using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.Security.Recaptcha
{
    public interface IRecaptchaValidator
    {
        Task ValidateAsync(string captchaResponse);
    }
}