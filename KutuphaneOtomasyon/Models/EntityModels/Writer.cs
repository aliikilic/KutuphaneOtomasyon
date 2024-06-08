namespace KutuphaneOtomasyon.Models.EntityModels
{
    public class Writer
    {
        public int WriterID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
