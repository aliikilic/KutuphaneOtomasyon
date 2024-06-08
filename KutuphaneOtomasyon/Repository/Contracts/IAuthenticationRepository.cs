using KutuphaneOtomasyon.Models.DataTransferObjects;
using Microsoft.AspNetCore.Identity;

namespace KutuphaneOtomasyon.Repository.Contracts
{
    public interface IAuthenticationRepository
    {
        Task<IdentityResult> RegisterUser(UserRegisterationDto userRegisterationDto);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuthenticationDto);
        Task<TokenDto> CreateToken(bool populateExp);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
        Task ChangePassword(string mail, string pass);
        Task<string> GetUserIdByEmail(string email);
    }
}
