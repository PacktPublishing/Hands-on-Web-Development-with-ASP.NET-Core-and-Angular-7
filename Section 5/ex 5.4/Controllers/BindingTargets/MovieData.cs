using System.ComponentModel.DataAnnotations;

namespace DVDMovie.Models.BindingTargets
{
    public class MovieData
    {
        [Required]
        public string Image { get => Movie.Image; set => Movie.Image = value; }
        [Required]
        public string Name { get => Movie.Name; set => Movie.Name = value; }
        [Required]
        public string Category { get => Movie.Category; set => Movie.Category = value; }
        [Required]
        public string Description { get => Movie.Description; set => Movie.Description = value; }
        [Range(1, int.MaxValue, ErrorMessage = "Price must be at least 1")]
        public decimal Price { get => Movie.Price; set => Movie.Price = value; }
        public long? Studio
        {
            get => Movie.Studio?.StudioId ?? null;
            set
            {
                if (!value.HasValue)
                {
                    Movie.Studio = null;
                }
                else
                {
                    if (Movie.Studio == null)
                    {
                        Movie.Studio = new Studio();
                    }
                    Movie.Studio.StudioId = value.Value;
                }
            }
        }
        public Movie Movie { get; set; } = new Movie();
    }
}
