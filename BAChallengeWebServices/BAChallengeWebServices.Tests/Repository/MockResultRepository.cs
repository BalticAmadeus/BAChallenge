using BAChallengeWebServices.Models;
using BAChallengeWebServices.Repository;
using BAChallengeWebServices.Tests.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BAChallengeWebServices.Tests.Repository
{
    public class MockResultRepository : IRepository<Result>
    {
        private readonly MockDbContext _dbContext;

        public MockResultRepository(MockDbContext dbContext)
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
                ResultId = item.ResultId,
                ActivityId = item.ActivityId,
                ParticipantId = item.ParticipantId,
                Points = item.Points,
                Description = item.Description,

            };
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

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
