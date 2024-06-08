using System.ComponentModel.DataAnnotations;

namespace KutuphaneOtomasyon.Models.DataTransferObjects
{
    public class UserRegisterationDto
    {
        public string? Email { get; set; }
        //public string? PhoneNumber { get; set; }
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor")]
        public string? ConfirmPassword { get; set; }
        public ICollection<string>? Roles { get; set; }
    }
}
