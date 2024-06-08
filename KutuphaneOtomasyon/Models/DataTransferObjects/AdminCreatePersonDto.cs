using KutuphaneOtomasyon.Models.EntityModels;

namespace KutuphaneOtomasyon.Models.DataTransferObjects
{
    public class AdminCreatePersonDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int CityID { get; set; }
        public int DistrictID { get; set; }
        public int NeighborhoodID { get; set; }
        public string AddressDescription { get; set; }
        public string UserID { get; set; }
    }
}
