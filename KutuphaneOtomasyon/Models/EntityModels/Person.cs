namespace KutuphaneOtomasyon.Models.EntityModels
{
    public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public City PersonCity { get; set; }
        public int CityID { get; set; }
        public District PersonDistrict { get; set; }
        public int DistrictID { get; set; }
        public Neighborhood PersonNeighborhood { get; set; }
        public int NeighborhoodID { get; set; }
        public string AddressDescription { get; set; }
        public string UserID { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<Borrow> Borrows { get; set; }

    }
}
