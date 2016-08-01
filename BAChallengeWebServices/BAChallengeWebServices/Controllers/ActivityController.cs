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
            //_dbContext.Activities.Add(act);
            //_dbContext.SaveChanges();
            var act = _dbContext.Activities.Where(x => x.Status == ActivityStatus.Open);
            return Ok(act);
        }
        public IHttpActionResult Delete(int id)
        {
            //return Ok();
            //int id = Int32.Parse(activityId);
            var activity = _dbContext.Activities.FirstOrDefault(u => u.ActivityId == id);
            if(activity != null)
            {
                _dbContext.Activities.Remove(activity);
                _dbContext.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
        public IHttpActionResult Put(int id,[FromBody]Activity activity)
        {
            var selectedRow = _dbContext.Activities.FirstOrDefault(u => u.ActivityId == id);
            if (selectedRow != null)
            {
                selectedRow.Name = activity.Name;
                selectedRow.Date = activity.Date;
                selectedRow.RegistrationDate = activity.RegistrationDate;
                selectedRow.Branch = activity.Branch;
                selectedRow.Status = activity.Status;
                selectedRow.Description = activity.Description;
                _dbContext.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
