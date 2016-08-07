using BAChallengeWebServices.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace BAChallengeWebServices.Models
{
    /// <summary>
    /// Model used to create Activity objects used for GET,POST, PUT, DELETE function
    /// </summary>
    public class Activity
    {
        public int ActivityId { get; set; }
        public string Name { get; set; }
        [JsonConverter(typeof(CustomTimeConverter))]
        public DateTime Date { get; set; }
        [JsonConverter(typeof(CustomTimeConverter))]
        public DateTime RegistrationDate { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ActivityStatus Status { get; set; }
        public string Description { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ActivityBranch Branch { get; set; }
        public string Location { get; set; }
        public string RegistrationUrl { get; set; }
    }

}