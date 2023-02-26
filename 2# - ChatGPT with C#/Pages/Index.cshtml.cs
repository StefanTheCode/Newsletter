using Microsoft.AspNetCore.Mvc.RazorPages;
using OpenAI_API;

namespace ChatGPTIntegration.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string Answer { get; set; }

        public void OnGet()
        {
        }

        public void OnPostSubmit(string question)
        {
            //Please use your OpenAIAPI. This one is deleted.
            var openAIAPI = new OpenAIAPI("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");

            string text = "This is some text.";

            string formattedText = text.ToProperCase();

            var completions = openAIAPI.Completions.CreateCompletionAsync(
                prompt: question,
                model: "text-davinci-003",
                max_tokens: 100,
                temperature: 0.5f
                );

            var completionsResult = completions.Result.Completions;

            if(completionsResult is not null && completionsResult.Count > 0)
            {
                Answer = completionsResult[0].Text;
            }
        }
    }
}