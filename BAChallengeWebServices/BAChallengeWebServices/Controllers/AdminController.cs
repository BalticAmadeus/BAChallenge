using BAChallengeWebServices.DataAccess;
using BAChallengeWebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text.RegularExpressions;

namespace BAChallengeWebServices.Controllers
{
    public class AdminController : ApiController
    {
        private ApplicationDBContext _dbContext;

        public AdminController()
        {
            _dbContext = new ApplicationDBContext();
        }
        public IHttpActionResult Put(int id, [FromBody]Admin admin)
        {
            var selectedRow = _dbContext.Admins.FirstOrDefault(u => u.AdminId == id);
            if (selectedRow != null)
            {
                selectedRow.Username = admin.Username;
                selectedRow.PasswordHash = admin.PasswordHash;
                _dbContext.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}