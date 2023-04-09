using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PlotTwist.Models;
using PlotTwist.Services;
using Services;

namespace PlotTwist.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AskAIController : ControllerBase
    {
        public AskAIController(IOptions<OpenAISettings> openAISettings, ILogger<MoviesController> logger, IMovieService movieService, IPromptService promptService)
        {
            PromptService = promptService;
            MovieService = movieService;
            Logger = logger;
            OpenAISettings = openAISettings;
        }

        public IPromptService PromptService { get; }
        public IMovieService MovieService { get; }
        public ILogger<MoviesController> Logger { get; }
        public IOptions<OpenAISettings> OpenAISettings { get; }

        // .../api/askai
        [HttpGet]
        public string GetAsync()
        {
            string response = Task.Run(() => PromptService.SendPrompt("Give me an enthusiastic 'Hello, World' message.")).Result;
            return response;
        }
    }
}
