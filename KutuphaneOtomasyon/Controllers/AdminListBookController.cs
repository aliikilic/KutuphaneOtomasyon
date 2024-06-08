using AutoMapper;
using KutuphaneOtomasyon.Models;
using KutuphaneOtomasyon.Models.DataTransferObjects;
using KutuphaneOtomasyon.Models.EntityModels;
using KutuphaneOtomasyon.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneOtomasyon.Controllers
{
    public class AdminListBookController : Controller
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public AdminListBookController(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var list = _manager.bookRepository.GetAllBooks(false);
            List<BookListDto> booklist = new List<BookListDto>();

            foreach (var book in list)
            {
                var writer = _manager.writerRepository.GetWriterByID(book.WriterId, false);
                var publisher = _manager.publisherRepository.GetPublisherNameById(book.PublisherId,false);
                
                booklist.Add( new BookListDto()
                { 
                    
                    WriterName = writer.Name +" "+ writer.Surname,
                    WriterId = writer.WriterID,
                    PublisherName = publisher,
                    PublisherId= book.PublisherId,
                    BookID = book.BookID,
                    Name = book.Name,
                    isActive = book.isActive,
                    TypeName = book.TypeName,
                    InitialIsActive = book.isActive,
                    Stock = Convert.ToInt32(book.Stock)

                });
            }
            ViewBag.BookList = booklist;
            return View();
        }

        public IActionResult ChangeBooksStatus(BookListDto book)
        {

            if (book.isActive != book.InitialIsActive || book.InitialStock != book.Stock)
            {
                if(book.isActive != book.InitialIsActive)  
                    book.isActive = !book.InitialIsActive;
                if(book.InitialStock != book.Stock)
                    book.Stock = book.InitialStock;
                    var mappedBook = _mapper.Map<Book>(book);
                _manager.bookRepository.UpdateOneBook(mappedBook);
            }
            //foreach (var book in bookList)
            //{
                
            //}
            return RedirectToAction("index", "AdminListBook");
        }
    }
}
