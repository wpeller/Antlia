using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace Fgv.Ide.Corporativohotsite.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}
