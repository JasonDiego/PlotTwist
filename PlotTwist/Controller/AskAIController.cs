using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlotTwist.Services;
using Services;

namespace PlotTwist.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AskAIController : ControllerBase
    {
        public AskAIController(ILogger<MoviesController> logger, IMovieService movieService, IPromptService promptService)
        {
            PromptService = promptService;
            MovieService = movieService;
            Logger = logger;
        }

        public IPromptService PromptService { get; }
        public IMovieService MovieService { get; }
        public ILogger<MoviesController> Logger;

        // .../api/askai
        [HttpGet]
        public string GetAsync()
        {
            string response = Task.Run(() => PromptService.SendDefaultPrompt()).Result;
            return "Hi, I'm PlotTwistAI. Don't you think plot twists are" + response + "?";
        }
    }
}
