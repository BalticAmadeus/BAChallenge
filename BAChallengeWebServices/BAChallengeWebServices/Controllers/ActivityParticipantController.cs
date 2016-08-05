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
    public class ActivityParticipantController : ApiController
    {
        private ApplicationDBContext _dbContext;

        public ActivityParticipantController()
        {
            _dbContext = new ApplicationDBContext();
        }

        public IHttpActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var activityParticipants = new List<ActivityParticipantModel>();
            foreach (var item in _dbContext.Activities.ToList())
            {
                activityParticipants.Add(GetActivityById(item.ActivityId));
            }
            return Ok(activityParticipants);
        }

        public IHttpActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (_dbContext.Activities.Where(x => x.ActivityId == id).Count() != 0)
            {
                return Ok(GetActivityById(id));
            }
            return NotFound();
        }

        private ActivityParticipantModel GetActivityById(int id)
        {
            var activity = _dbContext.Activities.Find(id);

            var participants = _dbContext.Participants.Where(x =>
            x.Results.Where(y => y.ActivityId == id).Count() != 0).ToList();

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
                        Firstname = x.FirstName,
                        Lastname = x.LastName,
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
