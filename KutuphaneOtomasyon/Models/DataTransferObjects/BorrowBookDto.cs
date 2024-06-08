namespace KutuphaneOtomasyon.Models.DataTransferObjects
{
    public class BorrowBookDto
    {
        public int PersonID { get; set; }
        public int BookID { get; set; }
        public DateTime BorrowinDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
