using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BAChallengeWebServices.DataAccess;
using BAChallengeWebServices.Models;

namespace BAChallengeWebServices.Repository
{
    public class ResultRepository : IRepository<Result>
    {
        private readonly ApplicationDbContext _dbContext;

        public ResultRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<Result> GetAll()
        {
            return _dbContext.Results.ToList();
        }
        public Result GetById(int id)
        {
            return _dbContext.Results.Find(id);
        }
        public bool Insert(Result item)
        {
            var results = new Result()
            {
                ActivityId = item.ActivityId,
                ParticipantId = item.ParticipantId,
                Points = item.Points,
                Description = item.Description
            };

            if (!_dbContext.ActivityParticipations.Any(x =>
                x.ActivityId == item.ActivityId &&
                x.ParticipantId == item.ParticipantId
                ))
            {
                return false;
            }

            if (_dbContext.Results.Any(x =>
                x.ActivityId == item.ActivityId &&
                x.ParticipantId == item.ParticipantId))
            {
                return false;
            }

            _dbContext.Results.Add(results);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var foundResult = _dbContext.Results.Find(id);
            _dbContext.Results.Remove(foundResult);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Modify(int id, Result item)
        {
            var foundResult = _dbContext.Results.Find(id);

            foundResult.ParticipantId = item.ParticipantId;
            foundResult.Points = item.Points;
            foundResult.Description = item.Description;
            foundResult.ActivityId = item.ActivityId;

            return _dbContext.SaveChanges() > 0;
        }
    }
}