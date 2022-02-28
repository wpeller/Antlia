using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.Identity
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}