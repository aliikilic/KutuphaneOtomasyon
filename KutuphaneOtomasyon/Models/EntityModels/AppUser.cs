using Microsoft.AspNetCore.Identity;

namespace KutuphaneOtomasyon.Models.EntityModels
{
    public class AppUser : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireTime { get; set; }

        public Person Person { get; set; }
    }
}
