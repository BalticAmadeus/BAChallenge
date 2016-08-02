using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAChallengeWebServices.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ActivityStatus Status { get; set; }
        public string Description { get; set; }
        public ActivityBranch Branch { get; set; }
    }

}