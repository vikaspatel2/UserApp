using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class Users: IdentityUser
    {
        public string FullName { get; set; }

        public int? CreateUid { get; set; }
        public DateTime? CreateDt { get; set; }
        public int? LModifyBy { get; set; }
        public DateTime? LModifyDt { get; set; }
        public int? DelUid { get; set; }
        public DateTime? DelDt { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
    }
}
