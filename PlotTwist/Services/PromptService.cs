using Microsoft.Extensions.Options;
using OpenAI_API;

namespace PlotTwist.Services
{
    public class PromptService : IPromptService
    {
        // constructor
        public PromptService() { _api = new OpenAI_API.OpenAIAPI("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"); }

        // internal members
        private OpenAIAPI _api;
        private static PromptService instance;

        // fetch instance
        public static PromptService Instance
        {
            get
            {
                instance ??= new PromptService();
                return instance;
            }
        }

        // send prompt via OpenAI API
        public async Task<string> SendPrompt()
        {
            // TODO: make prompt dynamic!
            return await _api.Completions.GetCompletion("Tell me a joke in 5 words.");
        }
    }
}
