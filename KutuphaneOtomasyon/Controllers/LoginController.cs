using KutuphaneOtomasyon.Models.DataTransferObjects;
using KutuphaneOtomasyon.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        private readonly IRepositoryManager _manager;

        public LoginController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            UserForAuthenticationDto user = new UserForAuthenticationDto()
            {
                Email = HttpContext.Session.GetString("userEmail")
            };

            
            return View(user); 
        }

        public async Task<IActionResult> LoginUser(UserForAuthenticationDto dto)
        {
            if (!await _manager.authenticationRepository.ValidateUser(dto))
                return RedirectToAction("index","Login");

            var tokenDto = await _manager.authenticationRepository.CreateToken(true);
            HttpContext.Session.SetString("userEmail", dto.Email);
            HttpContext.Session.SetString("userAccessToken",tokenDto.RefreshToken);
            return RedirectToAction("index", "UserHome");

        }
    }
}
