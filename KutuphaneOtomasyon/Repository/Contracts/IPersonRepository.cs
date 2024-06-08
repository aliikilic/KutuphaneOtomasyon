using KutuphaneOtomasyon.Models.EntityModels;

namespace KutuphaneOtomasyon.Repository.Contracts
{
    public interface IPersonRepository : IRepositoryBase<Person>
    {
        void CreatePerson(Person person);
        void DeletePerson(string email);
        
        Person GetOnePersonByEmail(string email);
        int GetOnePersonIdByEmail(string email);
    }
}
