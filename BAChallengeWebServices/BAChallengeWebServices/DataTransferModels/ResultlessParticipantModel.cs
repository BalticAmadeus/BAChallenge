using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BAChallengeWebServices.DataTransferModels
{
    /// <summary>
    /// Model used, to generate information about participants inside Excel file
    /// </summary>
    public class ResultlessParticipantModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Information { get; set; }
    }
}