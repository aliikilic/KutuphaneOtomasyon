using System.ComponentModel.DataAnnotations.Schema;

namespace KutuphaneOtomasyon.Models.EntityModels
{
    public class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CityID { get; set; }
        public string CityName { get; set; }

        public ICollection<District> Districts { get; set; }
        public ICollection<Neighborhood> Neighborhoods { get; set; }
        public ICollection<Person> Persons { get; set; }
        public ICollection<Publisher> Publishers { get; set; }
    }
}
