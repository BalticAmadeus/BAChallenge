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
        private readonly IActivityRepository _activityRepository;

        public ActivityController(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
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
            var activities = _activityRepository.GetAll();

            return activities.Any() ? (IHttpActionResult) Ok(activities) :  NotFound();
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
            var activity = _activityRepository.GetById(id);

            return activity != null ? (IHttpActionResult) Ok(activity) : NotFound();
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
            var activities = _activityRepository.GetByDate(date);

            return activities.Any() ? (IHttpActionResult) Ok(activities) : NotFound();
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
            var activities = _activityRepository.GetByLocation(location);

            return activities.Any() ? (IHttpActionResult) Ok(activities) : NotFound();
        }
        /// <summary>
        /// Function retrieves all activities selected by branch via .../activity/?branch=Seno (GET)
        /// </summary>
        /// <param name="branch">ActivityBrach object, gotten from http request</param>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(Activity))]
        [HttpGet]
        [Route("api/Activity")]
        public IHttpActionResult Get([FromUri]ActivityBranch branch)
        {
            var activities = _activityRepository.GetByBranch(branch);

            return activities.Any() ? (IHttpActionResult) Ok(activities) : NotFound();
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
            return _activityRepository.Insert(activity) ? (IHttpActionResult) Ok() : BadRequest();
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
            return _activityRepository.Delete(id) ? (IHttpActionResult) Ok() : NotFound();
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
            return _activityRepository.Modify(id, activity) ? (IHttpActionResult) Ok() : BadRequest();
        }

        protected override void Dispose(bool disposing)
        {
            _activityRepository.Dispose();

            base.Dispose(disposing);
        }
    }
}

