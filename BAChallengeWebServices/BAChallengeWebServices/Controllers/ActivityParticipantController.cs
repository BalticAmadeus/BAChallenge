using BAChallengeWebServices.DataAccess;
using BAChallengeWebServices.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BAChallengeWebServices.Utility;
using BAChallengeWebServices.DataTransferModels;

namespace BAChallengeWebServices.Controllers
{
    [ValidateModel]
    public class ActivityParticipantController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;

        public ActivityParticipantController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public IHttpActionResult Get()
        {
            var activityParticipants = _dbContext.Activities.ToList().Select(item => 
            GetActivityById(item.ActivityId)).ToList();

            return Ok(activityParticipants);
        }

        public IHttpActionResult Get(int id)
        {
            if (!_dbContext.Activities.Any(x => x.ActivityId == id))
            {
                return NotFound();
            }
            return Ok(GetActivityById(id));
        }

        private ActivityParticipantModel GetActivityById(int id)
        {
            var activity = _dbContext.Activities.Find(id);

            var participants = _dbContext.Participants.Where(x =>
            x.Results.Any(y => y.ActivityId == id)).ToList();

            var participantModel = new List<ParticipantModel>();

            participants.ForEach((x) =>
            {
                var results = new List<ResultParticipantModel>();
                x.Results.Where(y => y.ActivityId == id).ToList().ForEach(z =>
                    results.Add(new ResultParticipantModel
                    {
                        ResultId = z.ResultId,
                        Points = z.Points,
                        Description = z.Description
                    }
                ));
                participantModel.Add(
                    new ParticipantModel
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        ParticipantId = x.ParticipantId,
                        Results = results
                    });
            });
            return new ActivityParticipantModel
            {
                Activity = activity,
                Participants = participantModel
            };
        }
    }
}
