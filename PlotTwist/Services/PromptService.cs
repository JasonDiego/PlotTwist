using Microsoft.Extensions.Options;
using OpenAI_API;

namespace PlotTwist.Services
{
    public class PromptService : IPromptService
    {
        // constructor
        public PromptService(string key) { _api = new OpenAIAPI(key); }

        // internal members
        private OpenAIAPI _api;

        // send prompt via OpenAI API
        public async Task<string> SendPrompt()
        {
            // TODO: make prompt dynamic!
            return await _api.Completions.GetCompletion("Tell me a joke in a few words.");
        }
    }
}
