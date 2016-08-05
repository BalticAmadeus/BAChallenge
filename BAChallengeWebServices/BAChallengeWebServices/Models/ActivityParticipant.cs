using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAChallengeWebServices.Models
{
    public class ActivityParticipantModel
    {
        public virtual Activity Activity { get; set; }
        public virtual IList<ParticipantModel> Participants { get; set; }
    }
}