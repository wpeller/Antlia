using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.Security
{
    public interface IPasswordComplexitySettingStore
    {
        Task<PasswordComplexitySetting> GetSettingsAsync();
    }
}
