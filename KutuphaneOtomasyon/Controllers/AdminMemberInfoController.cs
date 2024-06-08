using AutoMapper;
using KutuphaneOtomasyon.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models.Adress;
using Newtonsoft.Json;
using KutuphaneOtomasyon.Models.DataTransferObjects;
using KutuphaneOtomasyon.Models.EntityModels;

namespace KutuphaneOtomasyon.Controllers
{
    public class AdminMemberInfoController : Controller
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public AdminMemberInfoController(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var Cityvalues = _manager.City.GetCities(false);
            var mappedCities = _mapper.Map<List<GetCitiesDto>>(Cityvalues);

            var Distictvalues =_manager.District.GetDistricts(false);
            var mappedDistricts = _mapper.Map<List<GetDistrictsDto>>(Distictvalues);
            
            var Neighborhoodvalues =_manager.Neighborhood.GetNeighborhoods(false);
            var mappedNeighborhoods = _mapper.Map<List<GetNeighborhoodsDto>>(Neighborhoodvalues);


            ViewBag.Cities = JsonConvert.SerializeObject(mappedCities);
            ViewBag.Districts = JsonConvert.SerializeObject(mappedDistricts);
            ViewBag.Neighborhoods = JsonConvert.SerializeObject(mappedNeighborhoods);
            return View();
        }

        public IActionResult SaveMemberInfo(AdminCreatePersonDto person)
        {
            person.UserID = HttpContext.Session.GetString("appUserId");
            person.Email = HttpContext.Session.GetString("userEmail");

            var mappedPerson = _mapper.Map<Person>(person);
            _manager.PersonRepository.CreatePerson(mappedPerson);
            return RedirectToAction("index","AdminBookList");
        }
    }
}
