using AutoMapper;
using KutuphaneOtomasyon.Models.DataTransferObjects;
using KutuphaneOtomasyon.Models.EntityModels;
using KutuphaneOtomasyon.Repository.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneOtomasyon.Controllers
{
    public class AdminAddBookController : Controller
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public AdminAddBookController(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateOneBook(CreateBookDto bookDto)
        {
            var mappedBook = _mapper.Map<Book>(bookDto);
            mappedBook.isActive = true;
            _manager.bookRepository.CreateOneBook(mappedBook);
            return RedirectToAction("Index","AdminAddBook");
        }

       
    }
}
