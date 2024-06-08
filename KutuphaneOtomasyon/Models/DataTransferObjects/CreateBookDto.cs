using KutuphaneOtomasyon.Models.EntityModels;

namespace KutuphaneOtomasyon.Models.DataTransferObjects
{
    public class CreateBookDto
    {
        public string Name { get; set; }
        public int WriterId { get; set; }
        public int PublisherId { get; set; }
        public string TypeName { get; set; }
        public int Stock { get; set; }
    }
}
