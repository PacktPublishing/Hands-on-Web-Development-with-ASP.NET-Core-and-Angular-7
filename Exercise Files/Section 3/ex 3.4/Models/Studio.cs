using System.Collections.Generic;

namespace DVDMovie.Models {
    public class Studio {

        public long StudioId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public IEnumerable<Movie> Movies { get; set; }
    }
}
