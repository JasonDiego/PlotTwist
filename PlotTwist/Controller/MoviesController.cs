using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace PlotTwist.Controller
{
    [Route("[controller]")]
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

        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return MovieService.GetMovies();
        }
    }
}
