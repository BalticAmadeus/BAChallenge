using System;
using System.Collections.Generic;
using BAChallengeWebServices.DataTransferModels;
using BAChallengeWebServices.Models;

namespace BAChallengeWebServices.Repository
{
    /// <summary>
    /// Interface used that has methods, used by repositories, retrieving ActivityParticipantModel DTO's, ActivityParticipation models.
    /// </summary>
    public interface IActivityParticipantRepository : IGetableById<ActivityParticipantModel>, IDisposable
    {
        /// <summary>
        /// Get every ActivityParticipantModel.
        /// </summary>
        /// <returns>IList of ActivityParticipantModels</returns>
        IList<ActivityParticipantModel> GetAll();
        /// <summary>
        /// Insert an ActivityParticipation item into database.
        /// </summary>
        /// <param name="item">Activity participation item</param>
        /// <returns>True if insert succeeded</returns>
        bool Insert(ActivityParticipation item);
        /// <summary>
        /// Delete an ActivityParticipation entry from database, using activityId and ParticipationId
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="participantId"></param>
        /// <returns>True if delete succeeded</returns>
        bool Delete(int activityId, int participantId);
        /// <summary>
        /// Modifies an ActivityParticipation entry in the database, which is found with activityId and participantId. Then it's information is changed.
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="participantId"></param>
        /// <param name="information"></param>
        /// <returns>True if modification succeeded</returns>
        bool Modify(int activityId, int participantId, string information);
    }
}