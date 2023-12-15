using DeducationApi.Models.RequestModels;

namespace DeducationApi.Repositories
{
    public interface IOCRRepository
    {
        public Task<List<string>> SummarizePdfFiles(IFormFile file1, IFormFile file2);
    }
}
