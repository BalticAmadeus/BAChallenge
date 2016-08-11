using BAChallengeWebServices.Models;
using System.Collections.Generic;

namespace BAChallengeWebServices.DataTransferModels
{
    /// <summary>
    /// Model used, for ActivityParticipation GET, PUT, POST, DELETE requests
    /// </summary>
    public class ActivityParticipantModel
    {
        public virtual Activity Activity { get; set; }
        public virtual IList<ParticipantModel> Participants { get; set; }
    }
}