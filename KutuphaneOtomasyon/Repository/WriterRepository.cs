using KutuphaneOtomasyon.Models.EntityModels;
using KutuphaneOtomasyon.Repository.Contracts;

namespace KutuphaneOtomasyon.Repository
{
    public class WriterRepository : RepositoryBase<Writer>, IWriterRepository
    {
        public WriterRepository(RepositoryContext context) : base(context)
        {
        }

        public Writer GetWriterByID(int id, bool trackChanges)
        {
            return FindByCondition(w => w.WriterID.Equals(id),trackChanges).SingleOrDefault();
        }
    }
}
