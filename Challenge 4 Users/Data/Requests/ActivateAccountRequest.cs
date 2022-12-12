using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Challenge_4_Users.Data.Requests {
    public class ActivateAccountRequest {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string ActivationCode { get; set; }
    }
}
