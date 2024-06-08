using KutuphaneOtomasyon.Models.EntityModels;
using KutuphaneOtomasyon.Repository.Contracts;

namespace KutuphaneOtomasyon.Repository
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneBook(Book book) => Create(book);

        public List<Book> GetAllActiveBooks(bool trackChanges)
        {
            return FindByCondition(b => b.isActive.Equals(true),trackChanges).ToList();
        }

        public List<Book> GetAllBooks(bool trackChanges)
        {
            return FindAll(trackChanges).ToList();
        }

        public List<Book> GetAllBooksWithType(bool trackChanges, string typeName)
        {
            
            return FindByCondition(b => b.TypeName.Equals(typeName), trackChanges).ToList();
        }

        public List<Book> GetAllBooksWithWriterName(bool trackChanges, int writerId)
        {
            return FindByCondition(b => b.WriterId.Equals(writerId), trackChanges).ToList();
        }

        public Book GetOneBookByID(int id, bool trackChanges)
        {
            return FindByCondition(b => b.BookID.Equals(id), trackChanges).FirstOrDefault();
        }

        public Book GetOneBookByName(bool trackChanges, string bookName)
        {
            return FindByCondition(b => b.Name.Equals(bookName), trackChanges).FirstOrDefault();
        }

        public void UpdateBorrowedBookStock(int bookId)
        {
            var book = FindByCondition(b => b.BookID.Equals(bookId),false).FirstOrDefault();
            book.Stock--;
            Update(book);
        }

        public void UpdateOneBook(Book book) => Update(book);
    }
}
