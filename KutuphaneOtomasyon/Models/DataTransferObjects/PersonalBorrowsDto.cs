namespace KutuphaneOtomasyon.Models.DataTransferObjects
{
    public class PersonalBorrowsDto
    {
        public string BookName { get; set; }
        public string WriterName { get; set; }
        public string PublisherName { get; set; }
        public string BorrowedDate { get; set; }
        public string ReturnDate { get; set; }
    }
}
