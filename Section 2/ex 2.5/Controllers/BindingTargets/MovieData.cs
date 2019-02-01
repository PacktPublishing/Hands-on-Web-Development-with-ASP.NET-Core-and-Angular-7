using System.ComponentModel.DataAnnotations;

namespace DVDMovie.Models.BindingTargets
{
    public class MovieData
    {
        [Required]
        public string Image{ get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Description { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Price must be at least 1")]
        public decimal Price { get; set; }
        public long Studio { get; set; }
        public Movie Movie => new Movie
        {
            Name = Name,
            Category = Category,
            Description = Description,
            Price = Price,
            Studio = Studio == 0 ? null : new Studio { StudioId = Studio }
        };
    }
}
