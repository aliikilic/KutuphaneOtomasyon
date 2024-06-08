using Microsoft.AspNetCore.Mvc;

namespace KutuphaneOtomasyon.Models.DataTransferObjects
{
    public class BookListForUserDto
    {
        public int BookID { get; set; }
        public string Name { get; set; }
        public string WriterName { get; set; }
        public int WriterId { get; set; }
        public string PublisherName { get; set; }
        public int PublisherId { get; set; }
        public string TypeName { get; set; }
        public int Stock { get; set; }

    }
}
