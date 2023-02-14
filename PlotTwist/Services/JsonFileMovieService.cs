using System.Text.Json;
using Models;

namespace Services
{
    public class JsonFileMovieService : IMovieService
    {
        public JsonFileMovieService(IWebHostEnvironment webHostEnvironment) => WebHostEnvironment = webHostEnvironment;

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName { get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "movies.json"); } }

        public IEnumerable<Movie> GetMovies()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                var movies = JsonSerializer.Deserialize<Movie[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return movies ?? Enumerable.Empty<Movie>();
            }
        }
    }
}
