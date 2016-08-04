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
    /// Model used to create Result objects, used for GET,POST, PUT, DELETE function
    /// </summary>
    public class Result
    {
        public int ResultId { get; set; }
        public virtual Activity Activity { get; set; }
        public int ActivityId { get; set; }
        public int Points { get; set; }
        public string Description { get; set; }
        public int ParticipantId { get; set; }
        [JsonIgnore]
        public virtual Participant Participant { get; set; }
    }
}