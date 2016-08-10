using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BAChallengeWebServices.DataAccess;
using BAChallengeWebServices.DataTransferModels;
using BAChallengeWebServices.Models;

namespace BAChallengeWebServices.Repository
{
    public class ResultlessActivityParticipantRepository : IGetableById<ResultlessActivityParticipantModel>, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;

        public ResultlessActivityParticipantRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets the activity participant model by activity Id
        /// </summary>
        /// <param name="id">Activity Id</param>
        /// <returns></returns>
        public ResultlessActivityParticipantModel GetById(int id)
        {
            var activityParticipants = _dbContext.ActivityParticipations.Where(x => x.ActivityId == id).ToList();

            return activityParticipants.Any() ? FormModel(id, activityParticipants) : null;


        }

        private ResultlessActivityParticipantModel FormModel(int id, List<ActivityParticipation> activityParticipation)
        {
            var activity = _dbContext.Activities.FirstOrDefault(x => x.ActivityId == id);

            if (activity == null)
            {
                return null;
            }

            var participantList = new List<ResultlessParticipantModel>();

            int listId = 1;
            activityParticipation.ForEach(x =>
            {
                var participant = _dbContext.Participants.Find(x.ParticipantId);

                participantList.Add(new ResultlessParticipantModel()
                {
                    Id = listId++,
                    FirstName = participant.FirstName,
                    LastName = participant.LastName,
                    Information = x.Information
                });
            });

            return new ResultlessActivityParticipantModel()
            {
                Activity = activity,
                Participants = participantList
            };

        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}