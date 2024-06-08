using System.ComponentModel.DataAnnotations.Schema;

namespace KutuphaneOtomasyon.Models.EntityModels
{
    public class Neighborhood
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NeighborhoodId { get; set; }
        public string NeighborhoodName { get; set; }
        public int DistrictId { get; set; }
        public int CityId { get; set; }

        public District District { get; set; }
        public City City { get; set; }

        public ICollection<Person> Persons { get; set; } 
        public ICollection<Publisher> Publishers{ get; set; } 
    }
}
