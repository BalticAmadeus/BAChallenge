using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAChallengeWebServices.Models
{
    public class ActivityParticipation
    {
        public int ActivityParticipationId { get; set; }
        public int ActivityId { get; set; }
        public int ParticipantId { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual Participant Participant { get; set; }
    }
}