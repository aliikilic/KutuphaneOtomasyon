using KutuphaneOtomasyon.Models.DataTransferObjects;

namespace KutuphaneOtomasyon.Models
{
    public class BookListViewModel
    {
        public List<BookListDto> Books { get; set; } = new List<BookListDto>();
    }
}
