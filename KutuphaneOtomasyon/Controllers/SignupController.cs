using KutuphaneOtomasyon.Models.DataTransferObjects;
using KutuphaneOtomasyon.Repository.Config;
using KutuphaneOtomasyon.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace KutuphaneOtomasyon.Controllers
{
    public class SignupController : Controller
    {
        private readonly IRepositoryManager _manager;

        public SignupController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Signup(UserRegisterationDto dto)
        {
            ICollection<string> roles = new List<string> { "user" };
            dto.Roles = roles;
            var result = await _manager.authenticationRepository.RegisterUser(dto);
            if (!result.Succeeded)
                return RedirectToAction("index","Signup");
            
            HttpContext.Session.SetString("userEmail",dto.Email);
            return RedirectToAction("index","Login");
        }
    }
}
