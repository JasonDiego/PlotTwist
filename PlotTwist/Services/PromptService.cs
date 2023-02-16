using OpenAI_API;

namespace PlotTwist.Services
{
    public class PromptService : IPromptService
    {
        // constructor
        public PromptService() { _api = new OpenAI_API.OpenAIAPI(); }

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
        public string SendPrompt()
        {
            // TO DO
            return "";
        }
    }
}
