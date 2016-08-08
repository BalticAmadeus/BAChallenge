using BAChallengeWebServices.DataAccess;
using BAChallengeWebServices.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BAChallengeWebServices.Controllers
{
    public class ActivityParticipantController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;

        public ActivityParticipantController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public IHttpActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var activityParticipants = _dbContext.Activities.ToList().Select(item => 
            GetActivityById(item.ActivityId)).ToList();
            return Ok(activityParticipants);
        }

        public IHttpActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (_dbContext.Activities.Any(x => x.ActivityId == id))
            {
                return Ok(GetActivityById(id));
            }
            return NotFound();
        }

        private ActivityParticipantModel GetActivityById(int id)
        {
            var activity = _dbContext.Activities.Find(id);

            var participants = _dbContext.Participants.Where(x =>
            x.Results.Count(y => y.ActivityId == id) != 0).ToList();

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
