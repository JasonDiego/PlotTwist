using System.Text.Json;
using Models;

namespace Services
{
    public class JsonFileMovieService : IMovieService
    {
        // constructor
        public JsonFileMovieService(IWebHostEnvironment webHostEnvironment)
        { 
            WebHostEnvironment = webHostEnvironment;

            try
            {
                string JsonFileName = Path.Combine(WebHostEnvironment.WebRootPath, "data", "movies.json");

                // read movies from JSON file
                using (var jsonFileReader = File.OpenText(JsonFileName))
                {
                    var movieList = JsonSerializer.Deserialize<Movie[]>(jsonFileReader.ReadToEnd(),
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    if (movieList == null)
                        throw new ArgumentNullException(nameof(movieList) + " is empty. Check path: " + JsonFileName);

                    // initialize dictionary
                    int count = 1;
                    foreach (var movie in movieList)
                    {
                        Movies.Add(count++, movie);
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine($"Failed to read JSON file. Exception: {ex.Message}");
            }
        }

        public IWebHostEnvironment WebHostEnvironment { get; }
        public Dictionary<int, Movie> Movies = new Dictionary<int, Movie>();

        public IEnumerable<Movie> GetMovies()
        {
            foreach(var movie in Movies) { Console.WriteLine(movie.Key + ": " + movie.Value); }
            return Movies.Values;
        }


    }
}
