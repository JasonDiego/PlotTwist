namespace PlotTwist.Services
{
    public class PromptService : IPromptService
    {
        private PromptService() { }
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
            var api = new OpenAI_API.OpenAIAPI();

            return "";
        }
    }
}
