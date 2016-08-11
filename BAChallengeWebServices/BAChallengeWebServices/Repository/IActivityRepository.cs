using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BAChallengeWebServices.Models;

namespace BAChallengeWebServices.Repository
{
    /// <summary>
    /// Interface, inheriting base IRepository of type Activity. That adds activity specific getters.
    /// </summary>
    public interface IActivityRepository : IRepository<Activity>
    {
        /// <summary>
        /// Gets List of Activities by location.
        /// </summary>
        /// <param name="location">Location</param>
        /// <returns>IList of activites</returns>
        IList<Activity> GetByLocation(string location);
        /// <summary>
        /// Gets list of Activites by branch.
        /// </summary>
        /// <param name="branch">ActivityBranch enum</param>
        /// <returns>IList of activities</returns>
        IList<Activity> GetByBranch(ActivityBranch branch);
        /// <summary>
        /// Gets List of Activites by Date.
        /// </summary>
        /// <param name="date">Date</param>
        /// <returns>IList of activities</returns>
        IList<Activity> GetByDate(DateTime date);
    }
}