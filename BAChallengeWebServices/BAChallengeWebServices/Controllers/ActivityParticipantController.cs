﻿using BAChallengeWebServices.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BAChallengeWebServices.DataTransferModels;
using BAChallengeWebServices.Utility;

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
                var result = x.Results.FirstOrDefault(y => y.ActivityId == id);

                participantModel.Add(
                    new ParticipantModel
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        ParticipantId = x.ParticipantId,
                        
                        Result = (result == null) ? 
                        new ResultParticipantModel() : 
                        new ResultParticipantModel
                        {
                            ResultId = result.ResultId,
                            Description = result.Description,
                            Points = result.Points
                        }
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
