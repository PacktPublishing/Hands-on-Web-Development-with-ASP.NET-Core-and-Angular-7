import { Component, Input } from "@angular/core";
import { Movie } from "../models/movie.model";
@Component({
    selector: "store-ratings",
    templateUrl: "ratings.component.html"
})
export class RatingsComponent {
    @Input()
    movie: Movie;
    get stars(): boolean[] {
        if (this.movie != null && this.movie.ratings != null) {
            let total = this.movie.ratings.map(r => r.stars)
                .reduce((prev, curr) => prev + curr, 0);
            let count = Math.round(total / this.movie.ratings.length);
            return Array(5).fill(false).map((value, index) => {
                return index < count;
            });
        } else {
            return [];
        }
    }
}
