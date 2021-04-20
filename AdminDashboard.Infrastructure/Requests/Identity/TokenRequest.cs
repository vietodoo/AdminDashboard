using System.ComponentModel.DataAnnotations;

namespace AdminDashboard.Infrastructure.Requests.Identity
{
    public class TokenRequest
    {
        [Required]
        public string Phone { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
