using KutuphaneOtomasyon.Models.EntityModels;

namespace KutuphaneOtomasyon.Repository.Contracts
{
    public interface IBorrowRepository : IRepositoryBase<Borrow>
    {
        void CreateBorrow(Borrow borrow);
        List<Borrow> GetPersonalBorrows(int personId);
    }
}
