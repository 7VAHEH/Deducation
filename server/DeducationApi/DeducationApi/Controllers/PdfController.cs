//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Http;
//using System.IO;
//using System.Threading.Tasks;
//using Tesseract;
//using Microsoft.AspNetCore.Http.HttpResults;

//[Route("api/[controller]")]
//[ApiController]
//public class PdfController : ControllerBase
//{
//    [HttpPost("upload")]
//    public async Task<IActionResult> UploadPdf(IFormFile pdfFile)
//    {
//        try
//        {
//            if (pdfFile == null || pdfFile.Length == 0)
//                return BadRequest("Please upload a PDF file.");

//            using (var ms = new MemoryStream())
//            {
//                await pdfFile.CopyToAsync(ms);
//                var text = PerformOCR(ms.ToArray());

//                // Perform text summarization here if needed

//                return Ok(new { summary = text });
//            }
//        }
//        catch (Exception ex)
//        {
//            return StatusCode(500, $"Internal server error: {ex.Message}");
//        }
//    }

//    private string PerformOCR(byte[] imageData)
//    {
//        using (var engine = new TesseractEngine(@"C:\Users\Garo\Desktop\TestProjects\DeducationApi\tessdata-main\tessdata-main", "eng", EngineMode.Default))
//        {
//            using (var img = Pix.LoadFromMemory(imageData))
//            {
//                using (var page = engine.Process(img))
//                {
//                    return page.GetText();
//                }
//            }
//        }
//    }
//}