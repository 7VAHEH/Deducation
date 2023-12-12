// Install the Tesseract.Net NuGet package
// Install the Microsoft.AspNetCore.Mvc.NewtonsoftJson NuGet package for JSON serialization

using java.awt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IronOcr;
using System.Diagnostics;

[ApiController]
[Route("[controller]")]
public class OCRController : ControllerBase
{
    [HttpPost("upload")]
    public IActionResult UploadFile(IFormFile[] pdfFiles)
    {
        if (pdfFiles == null || pdfFiles.Length == 0)
            return BadRequest("No file uploaded.");

        List<string> extractedStrings = new List<string>();

        foreach (IFormFile pdfFile in pdfFiles)
        {
            try
            {
                var ocr = new IronTesseract();

                using (var image = new OcrInput(pdfFile.OpenReadStream()))
                {
                    var result = ocr.Read(image);

                    if (result != null)
                    {
                        var extractedText = result.Text;
                        var str = extractedText.Remove(extractedText.Length - 454);

                        string inputText = str;

                        string summary = GetSummaryFromPythonScript(inputText);

                        if (pdfFile == null || pdfFile.Length == 0)
                            return BadRequest("No file uploaded.");

                        extractedStrings.Add(summary);
                    }
                    else
                    {
                        return BadRequest("Failed to extract text from the image.");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        return Ok(extractedStrings);
    }


    static string GetSummaryFromPythonScript(string inputText)
    {
        string pythonScriptPath = "C:\\Users\\Garo\\Desktop\\TestProjects\\DeducationApi\\summarizer.py"; // Update with the correct path

        using (Process process = new Process())
        {
            process.StartInfo.FileName = "python";
            process.StartInfo.Arguments = $"{pythonScriptPath}";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            process.Start();

            using (StreamWriter writer = process.StandardInput)
            {
                if (writer.BaseStream.CanWrite)
                {
                    writer.Write(inputText);
                }
            }

            using (StreamReader reader = process.StandardOutput)
            {
                return reader.ReadToEnd();
            }
        }
    }
}