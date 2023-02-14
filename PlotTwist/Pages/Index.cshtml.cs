using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services;

namespace PlotTwist.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public readonly IMovieService _movieService;
        public IEnumerable<Movie> Movies { get; private set; }

        // ILogger and IMovieService use dependency injection
        public IndexModel(ILogger<IndexModel> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        public void OnGet()
        {
            Movies = _movieService.GetMovies();
        }
    }
}