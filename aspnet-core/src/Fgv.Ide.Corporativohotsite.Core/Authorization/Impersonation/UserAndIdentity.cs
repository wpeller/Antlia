using System.Security.Claims;
using Fgv.Ide.Corporativohotsite.Authorization.Users;

namespace Fgv.Ide.Corporativohotsite.Authorization.Impersonation
{
    public class UserAndIdentity
    {
        public User User { get; set; }

        public ClaimsIdentity Identity { get; set; }

        public UserAndIdentity(User user, ClaimsIdentity identity)
        {
            User = user;
            Identity = identity;
        }
    }
}