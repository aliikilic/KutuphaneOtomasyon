namespace KutuphaneOtomasyon.Models.EntityModels
{
    public class Publisher
    {
        public int PublisherID { get; set; }
        public string Name { get; set; }
        public City PublisherCity { get; set; }
        public int CityId { get; set; }
        public District PublisherDistrict { get; set; }
        public int DistrictId { get; set; }
        public Neighborhood PublisherNeighborhood { get; set; }
        public int NeighborhoodId { get; set; }
        public string AddressDescription { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Book> Book { get; set; }
    }
}
