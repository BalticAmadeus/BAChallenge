using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BAChallengeWebServices.Models
{
    /// <summary>
    /// Model used, to create ActivityParticipation object, used for ActivityParticipantController POST request
    /// </summary>
    public class ActivityParticipation
    {
        
        public int ActivityParticipationId { get; set; }
        [Required]
        public int ActivityId { get; set; }
        [Required]
        public int ParticipantId { get; set; }
        public string Information { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual Participant Participant { get; set; }
    }
}