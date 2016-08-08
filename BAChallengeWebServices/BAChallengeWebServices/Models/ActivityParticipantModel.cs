using System.Collections.Generic;

namespace BAChallengeWebServices.Models
{
    public class ActivityParticipantModel
    {
        public virtual Activity Activity { get; set; }
        public virtual IList<ParticipantModel> Participants { get; set; }
    }
}