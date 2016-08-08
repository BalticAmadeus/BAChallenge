using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BAChallengeWebServices.DataAccess;
using BAChallengeWebServices.Models;

namespace BAChallengeWebServices.Repository
{
    public class ActivityRepository : IRepository<Activity>
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

        public void Insert(Activity item)
        {
            _dbContext.Activities.Add(item);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var foundActivity = _dbContext.Activities.Find(id);
            _dbContext.Activities.Remove(foundActivity);
        }

        public void Modify(int id, Activity item)
        {
            var foundActivity = _dbContext.Activities.Find(id);

            foundActivity.Branch = item.Branch;
            foundActivity.Date = item.Date;
            foundActivity.Description = item.Description;
            foundActivity.Location = item.Location;
            foundActivity.Name = item.Name;
            foundActivity.RegistrationDate = item.RegistrationDate;
            foundActivity.RegistrationUrl = item.RegistrationUrl;

            _dbContext.SaveChanges();
        }
    }
}