using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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