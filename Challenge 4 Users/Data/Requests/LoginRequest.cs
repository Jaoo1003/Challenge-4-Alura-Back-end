using System.ComponentModel.DataAnnotations;

namespace Challenge_4_Users.Data.Requests {
    public class LoginRequest {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
