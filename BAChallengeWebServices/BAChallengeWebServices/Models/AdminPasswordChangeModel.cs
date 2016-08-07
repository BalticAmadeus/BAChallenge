using System.ComponentModel.DataAnnotations;

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