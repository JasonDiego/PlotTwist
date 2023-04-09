using System.ComponentModel.DataAnnotations;

namespace PlotTwist.Models
{
    public class OpenAISettings
    {
        [Required]
        public string APIKey { get; set; }
    }
}
