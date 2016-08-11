﻿using BAChallengeWebServices.DataAccess;
using BAChallengeWebServices.DataTransferModels;
using System.Collections.Generic;
using System.Linq;
using BAChallengeWebServices.Models;

namespace BAChallengeWebServices.Repository
{
    public class ActivityParticipantRepository : IActivityParticipantRepository
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

        public bool Insert(ActivityParticipation item)
        {
            if (_dbContext.ActivityParticipations.Any(x =>
            x.ActivityId == item.ActivityId &&
            x.ParticipantId == item.ParticipantId))
                return false;

            _dbContext.ActivityParticipations.Add(item);
            return _dbContext.SaveChanges() > 0;
        }

        public bool Delete(int activityId, int participantId)
        {
            var foundItem = _dbContext.ActivityParticipations.FirstOrDefault(
                x => x.ActivityId == activityId && x.ParticipantId == participantId);

            if (foundItem != null)
            {
                _dbContext.ActivityParticipations.Remove(foundItem);
            }

            return _dbContext.SaveChanges() > 0;
        }

        public bool Modify(int activityId, int participantId, string information)
        {
            var activityParticipation =
                _dbContext.ActivityParticipations.FirstOrDefault(
                    x => x.ActivityId == activityId && x.ParticipantId == participantId);

            if (activityParticipation == null)
            {
                return false;
            }

            activityParticipation.Information = information;

            return _dbContext.SaveChanges() > 0;
        }

        private ActivityParticipantModel GetActivityById(int id)
        {
            var activity = _dbContext.Activities.Find(id);
            var activityParticipation =
                _dbContext.ActivityParticipations.Where(y => y.ActivityId == activity.ActivityId).ToList();

            var participantModel = new List<ParticipantModel>();

            activityParticipation.ForEach((x) =>
            {
                var participant = _dbContext.Participants.Find(x.ParticipantId);
                var result = participant.Results.FirstOrDefault(y => y.ActivityId == id);

                participantModel.Add(
                    new ParticipantModel
                    {
                        FirstName = participant.FirstName,
                        LastName = participant.LastName,
                        ParticipantId = x.ParticipantId,
                        Information = x.Information,
                        Result = (result == null) ?
                        null :
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

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}