using DeducationApi.Models.DBModels;

namespace DeducationApi.Repositories
{
    public interface IUniversityRepository
    {
        public Task<List<University>> GetAllUniversities();
    }
}
