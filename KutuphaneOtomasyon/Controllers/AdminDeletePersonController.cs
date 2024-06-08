using AutoMapper;
using KutuphaneOtomasyon.Models.DataTransferObjects;
using KutuphaneOtomasyon.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneOtomasyon.Controllers
{
    public class AdminDeletePersonController : Controller
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public AdminDeletePersonController(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(string email)
        {
            var person = _manager.PersonRepository.GetOnePersonByEmail(email);
            var mappedPerson = _mapper.Map<AdminDeletePersonDto>(person);
            return RedirectToAction("index", "AdminCheckDeletePerson", mappedPerson);
        }
    }
}
