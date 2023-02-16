using Microsoft.AspNetCore.Mvc;
using Models;
using PlotTwist.Services;
using Services;

namespace PlotTwist.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        public MoviesController(ILogger<MoviesController> logger, IMovieService movieService, IPromptService promptService)
        {
            PromptService = promptService;
            MovieService = movieService;
            Logger = logger;
        }

        public IPromptService PromptService { get; }
        public IMovieService MovieService { get; }
        public ILogger<MoviesController> Logger;

        [Route("/movies")]
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return MovieService.GetMovies();
        }

        [Route("/movies/{id}")]
        [HttpGet]
        public string GetAsync([FromRoute] int id)
        {
            string response = Task.Run(() => PromptService.SendPrompt()).Result;
            
            return response;
        }
    }
}
