using KutuphaneOtomasyon.Models.DataTransferObjects;
using KutuphaneOtomasyon.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneOtomasyon.Controllers
{
    public class AdminCheckDeletePersonController : Controller
    {
        private readonly IRepositoryManager _manager;

        public AdminCheckDeletePersonController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DeletePerson(AdminDeletePersonDto personDto)
        {
            var person = _manager.PersonRepository.GetOnePersonByEmail(personDto.Email);
            _manager.PersonRepository.Delete(person);
            return RedirectToAction("index","AdminListBook");
        }
    }
}
