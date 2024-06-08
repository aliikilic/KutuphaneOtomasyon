using AutoMapper;
using KutuphaneOtomasyon.Models.EntityModels;
using KutuphaneOtomasyon.Repository.Contracts;
using Microsoft.AspNetCore.Identity;
using Repositories.Contracts;
using Repositories.EfCore;

namespace KutuphaneOtomasyon.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IBookRepository> _bookRepository;
        private readonly Lazy<IWriterRepository> _writerRepository;
        private readonly Lazy<IPublisherRepository> _publisherRepository;
        private readonly Lazy<IAuthenticationRepository> _authenticationRepository;
        private readonly Lazy<ICityRepository> _cityRepository;
        private readonly Lazy<IDistrictRepository> _districtRepository;
        private readonly Lazy<INeighborhoodRepository> _neighborhoodRepository;
        private readonly Lazy<IPersonRepository> _personRepository;
        private readonly Lazy<IBorrowRepository> _borrowRepository;


        public RepositoryManager(RepositoryContext context, IMapper mapper,
            UserManager<AppUser> userManager,
            IConfiguration configuration)
        {
            _context = context;
            _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(context));
            _writerRepository = new Lazy<IWriterRepository>(()=> new WriterRepository(context));
            _publisherRepository = new Lazy<IPublisherRepository>(()=> new PublisherRepository(context));
            _authenticationRepository = new Lazy<IAuthenticationRepository>(() => new AuthenticationRepository(mapper,userManager,configuration,context));
            _cityRepository = new Lazy<ICityRepository>(() => new CityRepository(context));
            _districtRepository = new Lazy<IDistrictRepository>(() => new DistrictRepository(context));
            _neighborhoodRepository = new Lazy<INeighborhoodRepository>(() => new NeighborhoodRepository(context));
            _personRepository = new Lazy<IPersonRepository>(() => new PersonRepository(context));
            _borrowRepository = new Lazy<IBorrowRepository>(() => new BorrowRepository(context));
        }

        public IBookRepository bookRepository => _bookRepository.Value;

        public IWriterRepository writerRepository => _writerRepository.Value;

        public IPublisherRepository publisherRepository => _publisherRepository.Value;

        public IAuthenticationRepository authenticationRepository => _authenticationRepository.Value;

        public ICityRepository City => _cityRepository.Value;

        public IDistrictRepository District => _districtRepository.Value;

        public INeighborhoodRepository Neighborhood => _neighborhoodRepository.Value;

        public IPersonRepository PersonRepository => _personRepository.Value;

        public IBorrowRepository BorrowRepository => _borrowRepository.Value;
    }
}
