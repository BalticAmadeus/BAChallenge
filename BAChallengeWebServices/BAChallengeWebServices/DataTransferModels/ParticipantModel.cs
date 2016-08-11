using System.Collections.Generic;

namespace BAChallengeWebServices.DataTransferModels
{
    /// <summary>
    /// Model used, for Participant GET, POST, PUT, DELETE requests
    /// </summary>
    public class ParticipantModel
    {
        public int ParticipantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ResultParticipantModel Result { get; set; }
    }
}