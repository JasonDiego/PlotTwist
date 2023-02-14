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
        public readonly IPromptService _promptService;
        public IEnumerable<Movie> Movies { get; private set; }

        // ILogger and IMovieService use dependency injection
        public IndexModel(ILogger<IndexModel> logger, IMovieService movieService, IPromptService promptService)
        {
            _logger = logger;
            _movieService = movieService;
            _promptService = promptService;
        }

        public void OnGet()
        {
            // read movies from JSON file
            Movies = _movieService.GetMovies();

            var promptService = PromptService.Instance;
            promptService.SendPrompt();
        }
    }
}