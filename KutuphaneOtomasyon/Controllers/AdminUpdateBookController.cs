using AutoMapper;
using KutuphaneOtomasyon.Models.DataTransferObjects;
using KutuphaneOtomasyon.Models.EntityModels;
using KutuphaneOtomasyon.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneOtomasyon.Controllers
{
    public class AdminUpdateBookController : Controller
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public AdminUpdateBookController(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public IActionResult Index(int id)
        {
            var book = _manager.bookRepository.GetOneBookByID(id,false);
            var mappedBook = _mapper.Map<BookListDto>(book);
            mappedBook.PublisherName = _manager.publisherRepository.GetPublisherNameById(book.PublisherId,false);
            var writer = _manager.writerRepository.GetWriterByID(book.WriterId, false);
            mappedBook.WriterName = writer.Name + " " + writer.Surname;
            return View(mappedBook);
        }

        public IActionResult UpdateBook(BookListDto bookdto)
        {
            var book = _mapper.Map<Book>(bookdto);
            _manager.bookRepository.Update(book);

            return RedirectToAction("index", "AdminListBook");
        }
    }
}
