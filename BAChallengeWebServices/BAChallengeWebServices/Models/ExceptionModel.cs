using System;
using System.ComponentModel.DataAnnotations;

namespace BAChallengeWebServices.Models
{
    public class ExceptionModel
    {
        [Key]
        public int ExceptionId { get; set; }
        public string ExceptionMessage { get; set; }
        public DateTime LogDate { get; set; }
        public string Source { get; set; }
        public string Trace { get; set; }
    }
}