using System.ComponentModel.DataAnnotations.Schema;

namespace KutuphaneOtomasyon.Models.EntityModels
{
    public class District
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
        public int CityID { get; set; }

        public City City { get; set; }
        public ICollection<Neighborhood> Neighborhoods { get; set; }
        public ICollection<Person> Persons { get; set; }
        public ICollection<Publisher> Publishers { get; set; }

    }
}
