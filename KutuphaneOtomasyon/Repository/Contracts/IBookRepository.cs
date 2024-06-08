using KutuphaneOtomasyon.Models.EntityModels;

namespace KutuphaneOtomasyon.Repository.Contracts
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        List<Book> GetAllBooks(bool trackChanges);
        List<Book> GetAllActiveBooks(bool trackChanges);
        Book GetOneBookByName(bool trackChanges,string bookName);
        List<Book> GetAllBooksWithWriterName(bool trackChanges,int writerId);
        List<Book> GetAllBooksWithType(bool trackChanges, string typeName);
        Book GetOneBookByID(int id, bool trackChanges);
        void UpdateBorrowedBookStock(int bookId);
        void CreateOneBook(Book book);
        void UpdateOneBook(Book book);
    }
}
