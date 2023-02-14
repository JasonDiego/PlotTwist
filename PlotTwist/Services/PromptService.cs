using OpenAI_API;

namespace PlotTwist.Services
{
    public class PromptService : IPromptService
    {
        public PromptService() { _api = new OpenAI_API.OpenAIAPI(); }
        private OpenAIAPI _api;
        private static PromptService instance = null;
        public static PromptService Instance
        {
            get
            {
                instance ??= new PromptService();
                return instance;
            }
        }
        public string SendPrompt()
        {
            return "";
        }
    }
}
