using System.ComponentModel.DataAnnotations;

namespace AdminDashboard.Infrastructure.Requests.Users
{
    public class UserRegisterRequest
    {
        [Required]
        public string fullName { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        public string status { get; set; }
        public string level { get; set; }
        public string gender { get; set; }
    }
}
