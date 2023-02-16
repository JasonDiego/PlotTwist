using System.Text.Json;

namespace Models
{
    public class Movie
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? Year { get; set; }
        public string[]? Director { get; set; }
        public double? Rating { get; set; }
        public string[]? Cast { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Movie>(this);
        
    }
}
