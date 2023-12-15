using Microsoft.AspNetCore.Mvc;
using IronOcr;
using System.Diagnostics;
using DeducationApi.Repositories;

[ApiController]
[Route("[controller]")]
public class OCRController : ControllerBase
{
    private readonly IOCRRepository _oCRRepository;
    public OCRController(IOCRRepository oCRRepository)
    {
        _oCRRepository = oCRRepository;
    }

    [HttpPost]
    [Route("FileSummarization")]
    public async Task<IActionResult> UploadFile(IFormFile file1, IFormFile file2)
    {
        if (file1 == null || file2 == null)
            return BadRequest("No file uploaded.");


        var result = await _oCRRepository.SummarizePdfFiles(file1, file2);
        if (result == null)
            return NotFound();

        return Ok(result);
    }
}