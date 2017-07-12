using BAChallengeWebServices.DataAccess;
using BAChallengeWebServices.DataTransferModels;
using System.Collections.Generic;
using System.Linq;
using BAChallengeWebServices.Models;
using System;

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
            return GetParticipationView(-1);
        }

        public ActivityParticipantModel GetById(int id)
        {
            return GetParticipationView(id).FirstOrDefault();
        }

        private List<ActivityParticipantModel> GetParticipationView(int activityId)
        {
            // This is still bad, but at least it doesn't do n+1 queries (almost; TODO bring sanity to DB model)
            var activities = _dbContext.Activities.ToList();
            var participations = _dbContext.ActivityParticipations.ToList();
            var participants = _dbContext.Participants.ToList();

            return activities.Where(a => activityId < 0 || a.ActivityId == activityId)
                .Select(a => new ActivityParticipantModel
                {
                    Activity = a,
                    Participants = participations.Where(pt => pt.ActivityId == a.ActivityId)
                    .Select(pt => Tuple.Create(pt, participants.Where(pc => pc.ParticipantId == pt.ParticipantId).FirstOrDefault()))
                    .Where(t => t.Item2 != null)
                    .Select(t => new ParticipantModel
                    {
                        ParticipantId = t.Item2.ParticipantId,
                        FirstName = t.Item2.FirstName,
                        LastName = t.Item2.LastName,
                        Information = t.Item1.Information,
                        Result = (t.Item2.Results == null) ? null : t.Item2.Results.Where(r => r.ActivityId == a.ActivityId)
                            .Select(r => new ResultParticipantModel
                            {
                                ResultId = r.ResultId,
                                Points = r.Points,
                                Description = r.Description
                            }).FirstOrDefault()
                    }).ToList()
                }).ToList();
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

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}