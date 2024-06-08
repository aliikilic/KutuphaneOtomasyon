using Repositories.Contracts;

namespace KutuphaneOtomasyon.Repository.Contracts
{
    public interface IRepositoryManager
    {
        IBookRepository bookRepository { get; }
        IWriterRepository writerRepository { get; }
        IPublisherRepository publisherRepository { get; }
        IAuthenticationRepository authenticationRepository { get; }
        ICityRepository City { get; }
        IDistrictRepository District { get; }
        INeighborhoodRepository Neighborhood { get; }
        IPersonRepository PersonRepository { get; } 
        IBorrowRepository BorrowRepository { get; }
    }
}
