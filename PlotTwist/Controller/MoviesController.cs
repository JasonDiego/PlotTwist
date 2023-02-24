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
        public MoviesController(ILogger<MoviesController> logger, IMovieService movieService)
        {
            MovieService = movieService;
            Logger = logger;
        }

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
            return $"Movie #{id}";
        }
    }
}
