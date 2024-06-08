using KutuphaneOtomasyon.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace KutuphaneOtomasyon.Controllers
{
    public class AdminMemberController : Controller
    {
        private readonly IRepositoryManager _manager;

        public AdminMemberController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ValidateMember(string email)
        {
            var appUserId = await _manager.authenticationRepository.GetUserIdByEmail(email);
            if (!appUserId.IsNullOrEmpty())
            {
                HttpContext.Session.SetString("appUserId",appUserId);
                HttpContext.Session.SetString("userEmail", email);
                return RedirectToAction("index","AdminMemberInfo");
            }
            return RedirectToAction("index","AdminMember");
        }
    }
}
