using DeducationApi.Models.DBModels;
using DeducationApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DeducationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UniversityController : Controller
    {
        private readonly IUniversityRepository universityRepository;

        public UniversityController(IUniversityRepository universityRepository)
        {
            this.universityRepository = universityRepository;
        }

        [HttpGet]
        [Route("GetAllUniversities")]
        public List<University> GetAllUniversities()
        {

            var top5Universities = GetUnis();
            return top5Universities;


            //var universities = await universityRepository.GetAllUniversities();
            //return universities;
        }

        [HttpPost]
        [Route("SendData")]
        public List<University> SendData(object obj)
        {

            var top5Universities = GetUnis();
            return top5Universities;


            //var universities = await universityRepository.GetAllUniversities();
            //return universities;
        }

        private List<University> GetUnis()
        {
            return new List<University>
            {
                new University { Id = Guid.NewGuid(), Name = "University A", Location = "City A", Description = "Description A", Website = "www.universityA.com" },
                new University { Id = Guid.NewGuid(), Name = "University B", Location = "City B", Description = "Description B", Website = "www.universityB.com" },
                new University { Id = Guid.NewGuid(), Name = "University C", Location = "City C", Description = "Description C", Website = "www.universityC.com" },
                new University { Id = Guid.NewGuid(), Name = "University D", Location = "City D", Description = "Description D", Website = "www.universityD.com" },
                new University { Id = Guid.NewGuid(), Name = "University E", Location = "City E", Description = "Description E", Website = "www.universityE.com" },
            };
        }

    }
}