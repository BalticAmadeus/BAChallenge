using BAChallengeWebServices.DataAccess;
using System.Collections.Generic;
using System.Linq;
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
        [ResponseType(typeof(ActivityParticipantModel))]
        [HttpGet]
        [Route("api/ActivityParticipant")]
        public IHttpActionResult Get()
        {
            var activityParticipants = _activityParticipantRepository.GetAll();
            return activityParticipants != null ? (IHttpActionResult) Ok(activityParticipants) : NotFound();
        }
        [ResponseType(typeof(ActivityParticipantModel))]
        [HttpGet]
        [Route("api/ActivityParticipant/{id}")]
        public IHttpActionResult Get(int id)
        {
            var getActivity = _activityParticipantRepository.GetById(id);
            return getActivity != null ? (IHttpActionResult) Ok(getActivity) : NotFound();
        }

        [ResponseType(typeof(IHttpActionResult))]
        [HttpPost]
        [Route("api/ActivityParticipant")]
        public IHttpActionResult Post(ActivityParticipation activityParticipation)
        {
            return _activityParticipantRepository.Insert(activityParticipation) ? (IHttpActionResult) Ok() : BadRequest();
        }

        [ResponseType(typeof(IHttpActionResult))]
        [HttpPost]
        [Route("api/ActivityParticipant/{activityId}/{participantId}")]
        public IHttpActionResult Delete(int activityId, int participantId)
        {
            return _activityParticipantRepository.Delete(activityId, participantId)
                ? (IHttpActionResult) Ok()
                : NotFound();
        }

    }
}
