
using System.Web.Http;
using System.Web.Http.Description;
using BAChallengeWebServices.DataTransferModels;
using BAChallengeWebServices.Models;
using BAChallengeWebServices.Utility;
using BAChallengeWebServices.Repository;

namespace BAChallengeWebServices.Controllers
{
    [ValidateModel]
    public class ActivityParticipantController : ApiController
    {
        private readonly IActivityParticipantRepository _activityParticipantRepository;

        public ActivityParticipantController(IActivityParticipantRepository activityParticipantRepository)
        {
            _activityParticipantRepository = activityParticipantRepository;
        }
        /// <summary>
        /// Function retrieves all ActivityParticipants via .../activityParticipant (GET)
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(ActivityParticipantModel))]
        [HttpGet]
        [Route("api/ActivityParticipant")]
        public IHttpActionResult Get()
        {
            var activityParticipants = _activityParticipantRepository.GetAll();
            return activityParticipants != null ? (IHttpActionResult) Ok(activityParticipants) : NotFound();
        }
        /// <summary>
        /// Function retrieves one ActivityParticipant via .../activityParticipant/1 (GET)
        /// </summary>
        /// <param name="id">int, gotten from http integer request</param>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(ActivityParticipantModel))]
        [HttpGet]
        [Route("api/ActivityParticipant/{id}")]
        public IHttpActionResult Get(int id)
        {
            var getActivity = _activityParticipantRepository.GetById(id);
            return getActivity != null ? (IHttpActionResult) Ok(getActivity) : NotFound();
        }
        /// <summary>
        /// Function creates ActivityParticiation via .../activityParticipant (POST)
        /// </summary>
        /// <param name="activityParticipation">ActivityParticipation object, gotten from http body request</param>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(IHttpActionResult))]
        [HttpPost]
        [Route("api/ActivityParticipant")]
        public IHttpActionResult Post(ActivityParticipation activityParticipation)
        {
            return _activityParticipantRepository.Insert(activityParticipation) ? (IHttpActionResult) Ok() : BadRequest();
        }
        /// <summary>
        /// Function deletes activityParticipant via .../activityParticipant/1/1 (DELETE)
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="participantId"></param>
        /// <returns></returns>
        [ResponseType(typeof(IHttpActionResult))]
        [HttpPost]
        [Route("api/ActivityParticipant/{activityId}/{participantId}")]
        [Authorize]
        public IHttpActionResult Delete(int activityId, int participantId)
        {
            return _activityParticipantRepository.Delete(activityId, participantId)
                ? (IHttpActionResult) Ok()
                : NotFound();
        }
        /// <summary>
        /// Function modifies one ActivityParticipant via .../activityParticipant/1/1 (PUT)
        /// </summary>
        /// <param name="activityId">int, gotten from http integer request</param>
        /// <param name="participantId">int, gotten from http integer request</param>
        /// <param name="information">int gotten from http body request</param>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(IHttpActionResult))]
        [HttpPut]
        [Route("api/ActivityParticipant/{activityId}/{participantId}")]
        [Authorize]
        public IHttpActionResult Put(int activityId, int participantId, [FromBody] string information)
        {
            return _activityParticipantRepository.Modify(activityId, participantId, information)
                ? (IHttpActionResult) Ok()
                : NotFound();
        }

        protected override void Dispose(bool disposing)
        {
            _activityParticipantRepository.Dispose();

            base.Dispose(disposing);
        }
    }
}
