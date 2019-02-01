namespace DVDMovie.Models {

    public class Rating {

        public long RatingId { get; set; }
        public int Stars { get; set; }
        public Movie Movie { get; set; }
    }
}
