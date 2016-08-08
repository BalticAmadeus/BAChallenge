using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BAChallengeWebServices.Models
{
    /// <summary>
    /// Model used to create Result objects, used for GET, POST, PUT, DELETE function
    /// </summary>
    public class Result
    {
        public int ResultId { get; set; }
        public virtual Activity Activity { get; set; }
        [Required]
        public int ActivityId { get; set; }
        public int Points { get; set; }
        public string Description { get; set; }
        [Required]
        public int ParticipantId { get; set; }
        [JsonIgnore]
        public virtual Participant Participant { get; set; }
    }
}