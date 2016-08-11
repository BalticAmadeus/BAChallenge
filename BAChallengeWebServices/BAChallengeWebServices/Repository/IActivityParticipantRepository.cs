using System;
using System.Collections.Generic;
using BAChallengeWebServices.DataTransferModels;
using BAChallengeWebServices.Models;

namespace BAChallengeWebServices.Repository
{
    public interface IActivityParticipantRepository : IGetableById<ActivityParticipantModel>, IDisposable
    {
        IList<ActivityParticipantModel> GetAll();
        bool Insert(ActivityParticipation item);
        bool Delete(int activityId, int participantId);
        bool Modify(int activityId, int participantId, string information);
    }
}