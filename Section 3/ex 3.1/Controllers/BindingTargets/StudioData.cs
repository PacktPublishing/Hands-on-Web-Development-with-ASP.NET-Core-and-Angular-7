using System.ComponentModel.DataAnnotations;
namespace DVDMovie.Models.BindingTargets
{
    public class StudioData
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string State { get; set; }
        public Studio Studio => new Studio
        {
            Name = Name,
            City = City,
            State = State
        };
    }
}
