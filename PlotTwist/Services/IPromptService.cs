namespace PlotTwist.Services
{
    // necessary for dependency injection
    public interface IPromptService
    {
        public Task<string> SendPrompt();
    }
}
