using BAChallengeWebServices.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAChallengeWebServices.Models
{
    /// <summary>
    /// Model used to create Participant objects, used for GET,POST, PUT, DELETE function
    /// </summary>
    public class Participant
    { 
        public int ParticipantId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public virtual IList<Result> Results { get; set; }
    }
}