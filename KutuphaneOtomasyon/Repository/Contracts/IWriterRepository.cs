using KutuphaneOtomasyon.Models.EntityModels;

namespace KutuphaneOtomasyon.Repository.Contracts
{
    public interface IWriterRepository: IRepositoryBase<Writer>
    {
        Writer GetWriterByID(int id, bool trackChanges);
    }
}
