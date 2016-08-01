using BAChallengeWebServices.DataAccess;
using BAChallengeWebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BAChallengeWebServices.Controllers
{
    public class ActivityController : ApiController
    {
        private ApplicationDBContext _dbContext;

        public ActivityController()
        {
            _dbContext = new ApplicationDBContext();
        }

        public IHttpActionResult Get()
        {
            var act = _dbContext.Activities;
            return Ok(act);
        }
        
        public IHttpActionResult Get(int id)
        {
            var act = _dbContext.Activities.Where(x => x.ActivityId == id);
            return Ok(act);
        }
    }
}
