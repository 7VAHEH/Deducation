using DeducationApi.Models;
using DeducationApi.Models.DBModels;

namespace DeducationApi.Repositories
{
    public class UniversityRepository : IUniversityRepository
    {
        private DeducationDBContext dBContext { get; set; }
        public UniversityRepository(DeducationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<List<University>> GetAllUniversities()
        {
            var universities = dBContext.Universities.ToList();
            return universities;
        }
    }
}
