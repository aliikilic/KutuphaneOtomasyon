using KutuphaneOtomasyon.Models.EntityModels;
using KutuphaneOtomasyon.Repository.Contracts;

namespace KutuphaneOtomasyon.Repository
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreatePerson(Person person) => Create(person);

        public void DeletePerson(string email)
        {
            var person = FindByCondition(p => p.Email.Equals(email), false).FirstOrDefault();
            Delete(person);
        }

        public Person GetOnePersonByEmail(string email)
        {
            return FindByCondition(p => p.Email.Equals(email), false).FirstOrDefault();

        }

        public int GetOnePersonIdByEmail(string email)
        {
            var person = FindByCondition(p => p.Email.Equals(email), false).FirstOrDefault();
            return person.PersonID;
        }
    }
}
