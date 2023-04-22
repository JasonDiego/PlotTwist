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

        // send string prompt via OpenAI API
        public async Task<string> SendPrompt(string prompt)
        {
            return await _api.Completions.GetCompletion(prompt);
        }

        // send test prompt via OpenAI API
        public async Task<string> SendDefaultPrompt()
        {
            return await _api.Completions.GetCompletion(
                "I love watching movies." +
                "I really love exciting plot twists." +
                "Sometimes, I like to make up fictional plot twists for movies that I like." +
                "Don't you think plot twists are"
            );
        }
    }
}
