using BAChallengeWebServices.DataAccess;
using BAChallengeWebServices.Models;
using BAChallengeWebServices.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using BAChallengeWebServices.Repository;

namespace BAChallengeWebServices.Controllers
{
    [AllowCrossSiteJson]
    [ValidateModel]
    public class ActivityController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;

        public ActivityController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Function retrieves all Activities and all information about them via .../activity (GET)
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(Activity))]
        [HttpGet]
        [Route("api/Activity")]
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
        [ResponseType(typeof(Activity))]
        [HttpGet]
        [Route("api/Activity/{id}")]
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
        [ResponseType(typeof(Activity))]
        [HttpGet]
        [Route("api/Activity")]
        public IHttpActionResult Get([FromUri] DateTime date)
        {
            var activities = new List<Activity>(_dbContext.Activities.Where(
                x => x.Date.Value.Year == date.Year &&
                x.Date.Value.Month == date.Month &&
                x.Date.Value.Day == date.Day
            ));

            if (!activities.Any())
            {
                return NotFound();
            }

            return Ok(activities);
        }

        /// <summary>
        /// Function retrieves all activities selected by location via .../activity/?location=Vilnius (GET)
        /// </summary>
        /// <param name="location">string, gotten from http string request</param>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(Activity))]
        [HttpGet]
        [Route("api/Activity")]
        public IHttpActionResult Get([FromUri] string location)
        {
            var activities = new List<Activity>(_dbContext.Activities.Where(x => x.Location == location));

            if (!activities.Any())
            {
                return NotFound();
            }
            return Ok(activities);
        }
        /// <summary>
        /// Function retrieves all activities selected by branch via .../activity/?branch=Sports (GET)
        /// </summary>
        /// <param name="branch">ActivityBrach object, gotten from http request</param>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(Activity))]
        [HttpGet]
        [Route("api/Activity")]
        public IHttpActionResult Get([FromUri]ActivityBranch branch)
        {
            var activity = new List<Activity>(_dbContext.Activities.Where(x => x.Branch == branch));

            if (!activity.Any())
            {
                return NotFound();
            }

            return Ok(activity);
        }
        /// <summary>
        /// Function creates one activity via .../activity (POST)
        /// </summary>
        /// <param name="activity">Activity object, gotten from http request body</param>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(IHttpActionResult))]
        [HttpPost]
        [Route("api/Activity")]
        [Authorize]
        public IHttpActionResult Post([FromBody] Activity activity)
        {
            if (_dbContext.Activities.Any(x => x.ActivityId == activity.ActivityId))
            {
                return BadRequest("Item already exists");
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
        [ResponseType(typeof(IHttpActionResult))]
        [HttpDelete]
        [Route("api/Activity/{id}")]
        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var activity = _dbContext.Activities.Find(id);
            if (activity == null)
            {
                return NotFound();
            }
            _dbContext.Activities.Remove(activity);
            var resultsToDelete = _dbContext.Results.Where(x => x.ActivityId == id);
            _dbContext.Results.RemoveRange(resultsToDelete);
            _dbContext.SaveChanges();

            return Ok();
        }

        /// <summary>
        /// Function modify one activity via .../activity/1 (PUT)
        /// </summary>
        /// <param name="id">int, gotten from http integer request</param>
        /// <param name="activity">Activity object, gotten from http request body</param>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(IHttpActionResult))]
        [HttpPut]
        [Route("api/Activity/{id}")]
        [Authorize]
        public IHttpActionResult Put(int id, [FromBody] Activity activity)
        {
            var selectedRow = _dbContext.Activities.Find(id);
            if (selectedRow == null)
            {
                return NotFound();
            }
            selectedRow.Name = activity.Name;
            selectedRow.Date = activity.Date;
            selectedRow.RegistrationDate = activity.RegistrationDate;
            selectedRow.Branch = activity.Branch;
            selectedRow.Description = activity.Description;
            selectedRow.Location = activity.Location;
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}

