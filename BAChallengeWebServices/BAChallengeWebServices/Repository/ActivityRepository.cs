using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BAChallengeWebServices.DataAccess;
using BAChallengeWebServices.Models;

namespace BAChallengeWebServices.Repository
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ActivityRepository(ApplicationDbContext dbContext)
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
            if (foundActivity == null)
            {
                return false;
            }
            _dbContext.Activities.Remove(foundActivity);
            _dbContext.Results.RemoveRange(_dbContext.Results.Where(x => x.ActivityId == foundActivity.ActivityId));
            _dbContext.ActivityParticipations.RemoveRange(
                _dbContext.ActivityParticipations.Where(x => x.ActivityId == foundActivity.ActivityId));

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
            _dbContext.Dispose();
        }
    }
}