using System.Threading.Tasks;
using Fgv.Ide.Corporativohotsite.Security.Recaptcha;

namespace Fgv.Ide.Corporativohotsite.Tests.Web
{
    public class FakeRecaptchaValidator : IRecaptchaValidator
    {
        public Task ValidateAsync(string captchaResponse)
        {
            return Task.CompletedTask;
        }
    }
}
