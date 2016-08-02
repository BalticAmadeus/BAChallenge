using BAChallengeWebServices.DataAccess;
using BAChallengeWebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace BAChallengeWebServices.Controllers
{
    public class TokenController : ApiController
    {
        private ApplicationDBContext _dbContext;
        public TokenController()
        {
            _dbContext = new ApplicationDBContext();
        }
        public IHttpActionResult Post([FromBody] Admin admin)
        {
            if (!Validation(admin))
            {
                return NotFound();
            }
            return Ok();
        }
        private bool Validation(Admin admin)
        {
            Regex regex = new Regex("^[a-zA-Z0-9]*$");
            if (admin.Username != null)
            {
                if (!regex.IsMatch(admin.Username))
                {
                    //Exception wrong value
                    return false;
                }
                
                var ad = _dbContext.Admins.Where(
                    x => x.PasswordHash == admin.PasswordHash &&
                         x.Username == admin.Username
                ).SingleOrDefault();
                if(ad == null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
