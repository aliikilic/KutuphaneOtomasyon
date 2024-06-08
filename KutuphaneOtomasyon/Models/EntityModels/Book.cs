namespace KutuphaneOtomasyon.Models.EntityModels
{
    public class Book
    {
        public int BookID { get; set; }
        public string Name { get; set; }
        public Writer Writer { get; set; }
        public int WriterId { get; set; }
        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }
        public string TypeName { get; set; }
        public bool isActive { get; set; }
        public int? Stock { get; set; }
        public ICollection<Borrow> Borrow { get; set; }
    }
}
