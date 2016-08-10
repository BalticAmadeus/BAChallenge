using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BAChallengeWebServices.DataTransferModels;
using BAChallengeWebServices.Models;

namespace BAChallengeWebServices.Repository
{
    public interface IActivityParticipantRepository : IDisposable
    {
        IList<ActivityParticipantModel> GetAll();
        ActivityParticipantModel GetById(int id);
        bool Insert(ActivityParticipation item);
        bool Delete(int activityId, int participantId);
    }
}