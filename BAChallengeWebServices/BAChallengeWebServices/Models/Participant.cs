﻿using System.Collections.Generic;

namespace BAChallengeWebServices.Models
{
    /// <summary>
    /// Model used to create Participant objects, used for GET,POST, PUT, DELETE function
    /// </summary>
    public class Participant
    { 
        public int ParticipantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual IList<Result> Results { get; set; }
    }
}