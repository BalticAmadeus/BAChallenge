using System.Collections.Generic;

namespace BAChallengeWebServices.Models
{
    public class ParticipantModel
    {
        public int ParticipantId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public virtual IList<ResultParticipantModel> Results { get; set; }
    }
}