using BAChallengeWebServices.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAChallengeWebServices.Models
{
    public class Result
    {
        public int ResultId { get; set; }
        public int Participant { get; set; }
        public int ActivityId { get; set; }
        public int Results { get; set; }
        public string Description { get; set; }
    }
}