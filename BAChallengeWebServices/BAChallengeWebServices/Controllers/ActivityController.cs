using BAChallengeWebServices.DataAccess;
using BAChallengeWebServices.Models;
using BAChallengeWebServices.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BAChallengeWebServices.Controllers
{
    [AllowCrossSiteJson]
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
            var act = _dbContext.Activities.Where(x => x.ActivityId == id).Single();

            if (act == null)
            {
                return NotFound();
            }

            return Ok(act);
        }
        public IHttpActionResult Get(DateTime date)
        {
            var act = _dbContext.Activities.Where(
                x => x.Date.Year == date.Year &&
                x.Date.Month == date.Month &&
                x.Date.Day == date.Day
            );

            if (act.Count() == 0)
            {
                return NotFound();
            }
            return Ok(act);
        }
        public IHttpActionResult Get(string location)
        {
            var act = _dbContext.Activities.Where(x => x.Location == location);

            if (act.Count() == 0)
            {
                return NotFound();
            }
            return Ok(act);
        }
        public IHttpActionResult Get(ActivityBranch branch)
        {
            var act = _dbContext.Activities.Where(x => x.Branch == branch);

            if (act.Count() == 0)
            {
                return NotFound();
            }

            return Ok(act);
        }
        public IHttpActionResult Post([FromBody] Activity activity)
        {

            if (_dbContext.Activities.Where(x => x.ActivityId == activity.ActivityId).Count() > 0)
            {
                return BadRequest();
            }
            _dbContext.Activities.Add(activity);
            _dbContext.SaveChanges();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
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
                selectedRow.Location = activity.Location;
                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}
