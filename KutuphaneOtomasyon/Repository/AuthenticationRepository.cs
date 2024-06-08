using AutoMapper;
using KutuphaneOtomasyon.Models.DataTransferObjects;
using KutuphaneOtomasyon.Models.EntityModels;
using KutuphaneOtomasyon.Repository.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace KutuphaneOtomasyon.Repository
{
    public class AuthenticationRepository : RepositoryBase<AppUser>, IAuthenticationRepository
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        private AppUser? _user;

        public AuthenticationRepository(IMapper mapper, UserManager<AppUser> userManager, IConfiguration configuration, RepositoryContext context) : base(context)
        {
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        

        public async Task<TokenDto> CreateToken(bool populateExp)
        {
            var signinCredentials = GetSigninCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signinCredentials, claims);

            var refreshToken = GenerateRefreshToken();
            _user.RefreshToken = refreshToken;

            if (populateExp)
                _user.RefreshTokenExpireTime = DateTime.Now.AddMinutes(10);

            await _userManager.UpdateAsync(_user);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new TokenDto()
            {
                AccesToken = accessToken,
                RefreshToken = refreshToken,
            };
        }
        public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
        {
            var principal = GetPrincipalFromExpiredToken(tokenDto.AccesToken);
            var user = await _userManager.FindByNameAsync(principal.Identity.Name);
            if (user is null
                || user.RefreshToken != tokenDto.RefreshToken
                || user.RefreshTokenExpireTime <= DateTime.Now)
                throw new Exception(" Token geçerli değil.....");

            _user = user;
            return await CreateToken(false);
        }
        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["secretKey"];

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["validIssuer"],
                ValidAudience = jwtSettings["validAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken is null ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Geçersiz Token....");
            }
            return principal;
        }
        public async Task<IdentityResult> RegisterUser(UserRegisterationDto userRegisterationDto)
        {
            var user = _mapper.Map<AppUser>(userRegisterationDto);

            user.EmailConfirmed = false;
            user.PhoneNumberConfirmed = false;
            user.TwoFactorEnabled = false;
            user.LockoutEnabled = false;
            user.AccessFailedCount = 0;
            user.UserName = userRegisterationDto.Email;

            var result = await _userManager.CreateAsync(user, userRegisterationDto.Password);

            if (result.Succeeded)
                await _userManager.AddToRolesAsync(user, userRegisterationDto.Roles);
            var x = result.Errors.ToList();
            return result;

        }
        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuthenticationDto)
        {
            _user = await _userManager.FindByNameAsync(userForAuthenticationDto.Email);

            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuthenticationDto.Password));

            if (!result)
                throw new Exception("Geçersiz kullanıcı... ");
            return result;
        }
        public async Task ChangePassword(string mail, string pass)
        {
            var user = await _userManager.FindByEmailAsync(mail);

            var x = user.PasswordHash;

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, pass);

            var y = user.PasswordHash;

            await _userManager.UpdateAsync(user);





        }
        private SigningCredentials GetSigninCredentials()
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["secretKey"]);

            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Sid, _user.Id)

            };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }
        private SecurityToken GenerateTokenOptions(SigningCredentials signinCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken
                (
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                signingCredentials: signinCredentials
                );
            return tokenOptions;
        }
        private string? GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        public async Task<string> GetUserIdByEmail(string email)
        {
            var entity = await FindByCondition(x => x.UserName.Equals(email), false).SingleOrDefaultAsync();
            return entity.Id.ToString();
        }
    }
}
