using BAChallengeWebServices.DataAccess;
using BAChallengeWebServices.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAChallengeWebServices.Repository
{
    public class ActivityParticipantRepository : IActivityParticipantRepository<ActivityParticipantModel>
    {
        private readonly ApplicationDbContext _dbContext;

        public ActivityParticipantRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<ActivityParticipantModel> GetAll()
        {
            var activityParticipants = _dbContext.Activities.ToList().Select(item =>
            GetActivityById(item.ActivityId)).ToList();
            return activityParticipants;
        }

        public ActivityParticipantModel GetById(int id)
        {
            return GetActivityById(id);
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