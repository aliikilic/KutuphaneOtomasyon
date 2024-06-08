using KutuphaneOtomasyon.Models.EntityModels;
using KutuphaneOtomasyon.Repository.Contracts;

namespace KutuphaneOtomasyon.Repository
{
    public class PublisherRepository : RepositoryBase<Publisher>, IPublisherRepository
    {
        public PublisherRepository(RepositoryContext context) : base(context)
        {
        }

        public string GetPublisherNameById(int id, bool trackChanges)
        {
            var publisher = FindByCondition(p=> p.PublisherID.Equals(id),trackChanges).FirstOrDefault();
            return publisher.Name;
        }
    }
}
