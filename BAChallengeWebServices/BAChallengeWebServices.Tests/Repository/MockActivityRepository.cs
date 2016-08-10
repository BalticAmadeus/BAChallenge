using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAChallengeWebServices.Models;
using BAChallengeWebServices.Repository;
using BAChallengeWebServices.Tests.DataAccess;

namespace BAChallengeWebServices.Tests.Repository
{
    public class MockActivityRepository : IActivityRepository
    {
        private readonly MockDbContext _dbContext;

        public MockActivityRepository(MockDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Activity> GetAll()
        {
            return _dbContext.Activities.ToList();
        }

        public Activity GetById(int id)
        {
            return _dbContext.Activities.Find(id);
        }

        public bool Insert(Activity item)
        {
            _dbContext.Activities.Add(item);
            return _dbContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var foundActivity = _dbContext.Activities.Find(id);
            if (foundActivity != null)
            {
                _dbContext.Activities.Remove(foundActivity);
            }
            return _dbContext.SaveChanges() > 0;
        }

        public bool Modify(int id, Activity item)
        {
            var foundActivity = _dbContext.Activities.Find(id);

            foundActivity.Branch = item.Branch;
            foundActivity.Date = item.Date;
            foundActivity.Description = item.Description;
            foundActivity.Location = item.Location;
            foundActivity.Name = item.Name;
            foundActivity.RegistrationDate = item.RegistrationDate;
            foundActivity.RegistrationUrl = item.RegistrationUrl;

            return _dbContext.SaveChanges() > 0;
        }

        public IList<Activity> GetByLocation(string location)
        {
            return _dbContext.Activities.Where(x => x.Location == location).ToList();
        }

        public IList<Activity> GetByBranch(ActivityBranch branch)
        {
            return _dbContext.Activities.Where(x => x.Branch == branch).ToList();
        }

        public IList<Activity> GetByDate(DateTime date)
        {
            return _dbContext.Activities.Where(
               x => x.Date.Value.Year == date.Year &&
               x.Date.Value.Month == date.Month &&
               x.Date.Value.Day == date.Day
           ).ToList();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
