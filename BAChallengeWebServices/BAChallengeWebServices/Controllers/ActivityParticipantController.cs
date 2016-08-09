using BAChallengeWebServices.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using BAChallengeWebServices.DataTransferModels;
using BAChallengeWebServices.Utility;
using BAChallengeWebServices.Repository;

namespace BAChallengeWebServices.Controllers
{
    [ValidateModel]
    public class ActivityParticipantController : ApiController
    {
        private readonly IActivityParticipantRepository<ActivityParticipantModel> _ActivityParticipantModelRepository;

        public ActivityParticipantController(IActivityParticipantRepository<ActivityParticipantModel> ActivityParticipantModelRepository)
        {
            _ActivityParticipantModelRepository = ActivityParticipantModelRepository;
        }
        [ResponseType(typeof(ActivityParticipantModel))]
        [HttpGet]
        [Route("api/ActivityParticipant")]
        public IHttpActionResult Get()
        {
            var activityParticipants = _ActivityParticipantModelRepository.GetAll();
            return activityParticipants != null ? (IHttpActionResult) Ok(activityParticipants) : NotFound();
        }
        [ResponseType(typeof(ActivityParticipantModel))]
        [HttpGet]
        [Route("api/ActivityParticipant/{id}")]
        public IHttpActionResult Get(int id)
        {
            var getActivity = _ActivityParticipantModelRepository.GetById(id);
            return getActivity != null ? (IHttpActionResult) Ok(getActivity) : NotFound();
        }
    }
}
