using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using PlotTwist.Services;
using Services;

namespace PlotTwist.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public readonly IMovieService _movieService;
        public IEnumerable<Movie> Movies { get; private set; }

        // all parameters are injected automatically
        public IndexModel(ILogger<IndexModel> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        public void OnGet()
        {
            // read movies from JSON file
            Movies = _movieService.GetMovies();
        }
    }
}