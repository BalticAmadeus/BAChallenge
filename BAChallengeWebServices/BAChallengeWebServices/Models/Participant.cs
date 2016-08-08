using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BAChallengeWebServices.Models
{
    /// <summary>
    /// Model used to create Participant objects, used for GET,POST, PUT, DELETE function
    /// </summary>
    public class Participant
    { 
        public int ParticipantId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public virtual IList<Result> Results { get; set; }
    }
}