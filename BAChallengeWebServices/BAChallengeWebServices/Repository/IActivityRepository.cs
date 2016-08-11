using System;
using System.Collections.Generic;
using BAChallengeWebServices.Models;

namespace BAChallengeWebServices.Repository
{
    public interface IActivityRepository : IRepository<Activity>
    {
        IList<Activity> GetByLocation(string location);
        IList<Activity> GetByBranch(ActivityBranch branch);
        IList<Activity> GetByDate(DateTime date);
    }
}