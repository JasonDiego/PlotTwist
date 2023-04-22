using Microsoft.AspNetCore.Mvc;
using Models;
using PlotTwist.Services;
using Services;

namespace PlotTwist.Controller
{
    [Route("api/[controller]")]
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

        // .../api/movies
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return MovieService.GetMovies();
        }

        // .../api/movies/{id}
        [HttpGet("{id}")]
        public string Get([FromRoute] int id)
        {
            if (id < 1)
                return "Invalid movie ID! Please populate 'id' field with a number between 1 - "
                    + MovieService.GetMovies().Count().ToString();

            Movie? movie = MovieService.GetMovieById(id);

            if (movie == null)
                return $"Movie #{id} not found!";

            string response = Task.Run(() => PromptService.SendPrompt(
                "Give me a plot twist for the " + movie.Year + " film: " + movie.Name
            )).Result;

            return response;
        }
    }
}
