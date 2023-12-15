using IronOcr;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;

namespace DeducationApi.Repositories
{
    public class OCRRepository : IOCRRepository
    {
        public async Task<List<string>> SummarizePdfFiles(IFormFile file1, IFormFile file2)
        {
            var resList = new List<string>();

            var txtRead = ReadFromFiles(file1, file2);
            if (txtRead == null)
                return null;

            resList.AddRange(txtRead);

            var textToSum = "";
            foreach (var item in txtRead)
            {
                textToSum += item;
            }

            var summarizedText = await SummarizeText(textToSum);
            resList.Add(summarizedText);
            return resList;
        }

        public List<string> ReadFromFiles(IFormFile file1, IFormFile file2)
        {
            List<IFormFile> pdfFiles = new List<IFormFile>() { file1, file2 };
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
                            extractedStrings.Add(str);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return extractedStrings;
        }

        public async Task<string> SummarizeText(string txt)
        {
            var requestBody = new
            {
                model = "gpt-3.5-turbo-instruct",
                prompt = $"summarize following text{txt}",
                max_tokens = 1500,
                temperature = 0.9f,
            };
            string endPoint = "https://api.openai.com/v1/completions";
            string apiKey = "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";

            string jonPayLoad = JsonConvert.SerializeObject(requestBody);
            var request = new HttpRequestMessage(HttpMethod.Post, endPoint);
            request.Headers.Add("Authorization", $"Bearer {apiKey}");
            request.Content = new StringContent(jonPayLoad, Encoding.UTF8, "application/json");

            var resText = "";
            using (HttpClient client = new HttpClient())
            {
                var response = client.SendAsync(request).GetAwaiter().GetResult();
               // var response = await client.SendAsync(request);
                using (Stream stream = await response.Content.ReadAsStreamAsync())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        char[] buffer = new char[4096]; // You can adjust the buffer size as needed

                        StringBuilder result = new StringBuilder();
                        int bytesRead;

                        do
                        {
                            bytesRead = await reader.ReadAsync(buffer, 0, buffer.Length);
                            result.Append(buffer, 0, bytesRead);
                        } while (bytesRead > 0);
                    }
                }

                var res = await response.Content.ReadAsStringAsync();
                TextCompletionResponse responseResult = JsonConvert.DeserializeObject<TextCompletionResponse>(res);

                foreach (Choice choice in responseResult.Choices)
                {
                    resText += choice.Text;
                }
            }

            return resText.IsNullOrEmpty() ? "Cant Summarize Text" : resText;
        }

        public class Choice
        {
            public string Text { get; set; }
        }

        public class TextCompletionResponse
        {
            public Choice[] Choices { get; set; }
        }
    }
}
