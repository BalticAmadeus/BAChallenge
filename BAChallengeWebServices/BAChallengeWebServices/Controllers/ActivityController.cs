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
            //Activity act = new Activity { ActivityId = 1, Name = "Begimas", Date = DateTime.Now, RegistrationDate = DateTime.Now, Branch = ActivityBranch.Brain, Status = ActivityStatus.Open, Description = "Blank" };
            var act = _dbContext.Activities.Where(x => x.Status == ActivityStatus.Open);
            return Ok(act);
        }
    }
}
