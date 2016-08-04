using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BAChallengeWebServices.Models
{
    /// <summary>
    /// Model, used for Admin put request
    /// </summary>
    public class AdminPasswordChangeModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }
}