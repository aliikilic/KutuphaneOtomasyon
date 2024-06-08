using AutoMapper;
using KutuphaneOtomasyon.Models.DataTransferObjects;
using KutuphaneOtomasyon.Models.EntityModels;
using KutuphaneOtomasyon.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneOtomasyon.Controllers
{
    public class UserHomeController : Controller
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public UserHomeController(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            var email = HttpContext.Session.GetString("userEmail");
            var person = _manager.PersonRepository.GetOnePersonByEmail(email);
            ViewData["person"] = person;

            var personEmail = HttpContext.Session.GetString("userEmail");
            var personID = _manager.PersonRepository.GetOnePersonIdByEmail(personEmail);


            var personalBorrows = _manager.BorrowRepository.GetPersonalBorrows(personID);
            List<PersonalBorrowsDto> edittedBorrows = new List<PersonalBorrowsDto>();
            foreach (var item in personalBorrows)
            {
                var book = _manager.bookRepository.GetOneBookByID(item.BookId, false);
                var writer = _manager.writerRepository.GetWriterByID(book.WriterId, false);
                var publisher = _manager.publisherRepository.GetPublisherNameById(book.PublisherId, false);
                edittedBorrows.Add(new PersonalBorrowsDto()
                {
                    BookName = book.Name,
                    WriterName = writer.Name + " " + writer.Surname,
                    PublisherName = publisher,
                    BorrowedDate = item.BorrowingDate.ToString("dd/MM/yyyy"),
                    ReturnDate = item.ReturnDate.ToString("dd.MM.yyyy")
                });
            }
            ViewBag.PersonalBorrows = edittedBorrows;




            var list = _manager.bookRepository.GetAllActiveBooks(false);
            List<BookListForUserDto> booklist = new List<BookListForUserDto>();

            foreach (var book in list)
            {
                var writer = _manager.writerRepository.GetWriterByID(book.WriterId, false);
                var publisher = _manager.publisherRepository.GetPublisherNameById(book.PublisherId, false);

                booklist.Add(new BookListForUserDto()
                {
                    BookID = book.BookID,
                    WriterName = writer.Name + " " + writer.Surname,
                    WriterId = writer.WriterID,
                    PublisherName = publisher,
                    PublisherId = book.PublisherId,
                    Name = book.Name,
                    TypeName = book.TypeName,
                    Stock = Convert.ToInt32(book.Stock)

                });
            }
            ViewBag.BookList = booklist;
            return View();
        }

        public IActionResult Borrowing(Borrow borrow)
        {
            var personEmail = HttpContext.Session.GetString("userEmail");
            var personID = _manager.PersonRepository.GetOnePersonIdByEmail(personEmail);

            borrow.PersonId = personID;
            borrow.BorrowingDate = DateTime.Now.ToLocalTime();
            borrow.ReturnDate = DateTime.Now.AddDays(15);

            //var mappedBorrow = _mapper.Map<Borrow>(dto);
            _manager.BorrowRepository.CreateBorrow(borrow);
            _manager.bookRepository.UpdateBorrowedBookStock(borrow.BookId);

            return RedirectToAction("index", "UserHome");

        }
    }
}
