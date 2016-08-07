using Microsoft.AspNet.Identity.EntityFramework;

namespace BAChallengeWebServices.DataAccess
{
    /// <summary>
    /// Identity database context, mainly used in AuthRepository.
    /// </summary>
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext() : base("ApplicationContext")
        {

        }
    }
}