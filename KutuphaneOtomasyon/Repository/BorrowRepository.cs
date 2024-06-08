using KutuphaneOtomasyon.Models.EntityModels;
using KutuphaneOtomasyon.Repository.Contracts;

namespace KutuphaneOtomasyon.Repository
{
    public class BorrowRepository : RepositoryBase<Borrow>, IBorrowRepository
    {
        public BorrowRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateBorrow(Borrow borrow) => Create(borrow);

        public List<Borrow> GetPersonalBorrows(int personId)
        {
            return FindByCondition(b=> b.PersonId.Equals(personId),false).ToList();
        }
    }
}
