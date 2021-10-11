using System.ComponentModel.DataAnnotations;

namespace ApplicationNET6PreviewSandbox.Models
{
    public class Country
    {
        [Key]
        public string Code { get; set; } = null!;

        public string Name { get; set; } = String.Empty;

        public string Continent { get; set; } = String.Empty;

        public string Region { get; set; } = String.Empty;

        public int Population { get; set; } = 0;
    }
}
