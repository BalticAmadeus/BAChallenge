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
        /// <summary>
        /// Function retrieves all Activities and all information about them via .../activity (GET)
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        public IHttpActionResult Get()
        {
            var act = _dbContext.Activities;

            return Ok(act);
        }
        /// <summary>
        /// Function retrieves One Activity selected by id and all information about the activity. via .../activity/1 (GET)
        /// </summary>
        /// <param name="id">int, gotten from http integer request</param>
        /// <returns>IHttpActionResult</returns>
        public IHttpActionResult Get(int id)
        {
            var act = _dbContext.Activities.Find(id);

            if (act == null)
            {
                return NotFound();
            }

            return Ok(act);
        }
        /// <summary>
        /// Function retrieves all activities selected by datetime via .../activity/?date=2016-04-22 11:30 (GET)
        /// </summary>
        /// <param name="date">DateTime, gotten from http date request </param>
        /// <returns>IHttpActionResult</returns>
        public IHttpActionResult Get(DateTime date)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

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
        /// <summary>
        /// Function retrieves all activities selected by location via .../activity/?location=Vilnius (GET)
        /// </summary>
        /// <param name="location">string, gotten from http string request</param>
        /// <returns>IHttpActionResult</returns>
        public IHttpActionResult Get(string location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var act = _dbContext.Activities.Where(x => x.Location == location);

            if (act.Count() == 0)
            {
                return NotFound();
            }
            return Ok(act);
        }
        /// <summary>
        /// Function retrieves all activities selected by branch via .../activity/?branch=Sports (GET)
        /// </summary>
        /// <param name="branch">ActivityBrach object, gotten from http request</param>
        /// <returns>IHttpActionResult</returns>
        public IHttpActionResult Get(ActivityBranch branch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var act = _dbContext.Activities.Where(x => x.Branch == branch);

            if (act.Count() == 0)
            {
                return NotFound();
            }

            return Ok(act);
        }
        /// <summary>
        /// Function creates one activity via .../activity (POST)
        /// </summary>
        /// <param name="activity">Activity object, gotten from http request body</param>
        /// <returns>IHttpActionResult</returns>
        [Authorize]
        public IHttpActionResult Post([FromBody] Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (_dbContext.Activities.Where(x => x.ActivityId == activity.ActivityId).Count() > 0)
            {
                return BadRequest();
            }
            _dbContext.Activities.Add(activity);
            _dbContext.SaveChanges();

            return Ok();
        }
        /// <summary>
        /// Function deletes one activity via .../activity/1 (DELETE)
        /// </summary>
        /// <param name="id">int, gotten from http integer request</param>
        /// <returns>IHttpActionResult</returns>
        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var activity = _dbContext.Activities.Find(id);
            if(activity != null)
            {
                _dbContext.Activities.Remove(activity);
                _dbContext.SaveChanges();

                return Ok();
            }

            return NotFound();
        }
        /// <summary>
        /// Function modify one activity via .../activity/1 (PUT)
        /// </summary>
        /// <param name="id">int, gotten from http integer request</param>
        /// <param name="activity">Activity object, gotten from http request body</param>
        /// <returns>IHttpActionResult</returns>
        [Authorize]
        public IHttpActionResult Put(int id,[FromBody]Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var selectedRow = _dbContext.Activities.Find(id);
            if (selectedRow != null)
            {
                selectedRow.Name = activity.Name;
                selectedRow.Date = activity.Date;
                selectedRow.RegistrationDate = activity.RegistrationDate;
                selectedRow.Branch = activity.Branch;
                selectedRow.Description = activity.Description;
                selectedRow.Location = activity.Location;
                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}
