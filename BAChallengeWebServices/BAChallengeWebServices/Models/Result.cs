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
        public int Activity { get; set; }
        public int Points { get; set; }
        public string Description { get; set; }
    }
}