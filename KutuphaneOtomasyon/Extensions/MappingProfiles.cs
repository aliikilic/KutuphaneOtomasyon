using AutoMapper;
using KutuphaneOtomasyon.Models;
using KutuphaneOtomasyon.Models.DataTransferObjects;
using KutuphaneOtomasyon.Models.EntityModels;
using WebUI.Models.Adress;

namespace KutuphaneOtomasyon.Extensions
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles() 
        {
            CreateMap<CreateBookDto, Book>();
            CreateMap<BookListDto, Book>().ReverseMap();
            CreateMap<BookListDto, BookListViewModel>().ReverseMap();
            CreateMap<UserRegisterationDto, AppUser>().ReverseMap();
            CreateMap<UserForAuthenticationDto, AppUser>().ReverseMap();


            CreateMap<GetCitiesDto, City>().ReverseMap();
            CreateMap<GetDistrictsDto, District>().ReverseMap();
            CreateMap<GetNeighborhoodsDto, Neighborhood>().ReverseMap();

            CreateMap<Person, AdminCreatePersonDto>().ReverseMap();
            CreateMap<Person, AdminDeletePersonDto>().ReverseMap();

            CreateMap<Borrow,BorrowBookDto>().ReverseMap();
        }
    }
}
