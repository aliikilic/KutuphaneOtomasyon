

using KutuphaneOtomasyon.Models.EntityModels;

namespace KutuphaneOtomasyon.Repository.Contracts
{
    public interface IPublisherRepository: IRepositoryBase<Publisher>
    {
        string GetPublisherNameById(int id, bool trackChanges);
    }
}
