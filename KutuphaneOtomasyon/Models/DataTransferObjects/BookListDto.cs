using KutuphaneOtomasyon.Models.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneOtomasyon.Models.DataTransferObjects
{
    public class BookListDto
    {
        public int BookID { get; set; }
        public string Name { get; set; }
        public string WriterName { get; set; }
        public int WriterId { get; set; }
        public string PublisherName { get; set; }
        public int PublisherId { get; set; }
        public string TypeName { get; set; }
        public int Stock { get; set; }
        public int InitialStock { get; set; }
        public bool isActive { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool InitialIsActive { get; set; }

    }
}
