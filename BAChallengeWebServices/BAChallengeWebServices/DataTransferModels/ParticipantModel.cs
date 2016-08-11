using System.Collections.Generic;

namespace BAChallengeWebServices.DataTransferModels
{
    public class ParticipantModel
    {
        public int ParticipantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Information { get; set; }
        public virtual ResultParticipantModel Result { get; set; }
    }
}