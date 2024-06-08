namespace KutuphaneOtomasyon.Models.EntityModels
{
    public class Borrow
    {
        public int BorrowID { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public DateTime BorrowingDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
