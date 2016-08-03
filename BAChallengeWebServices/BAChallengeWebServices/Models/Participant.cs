using BAChallengeWebServices.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAChallengeWebServices.Models
{
    public class Participants
    {
        public int ParticipantsId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}