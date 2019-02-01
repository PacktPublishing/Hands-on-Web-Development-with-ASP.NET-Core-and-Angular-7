import { Component } from "@angular/core";
import { Repository } from "../models/repository";
import { Movie } from "../models/movie.model";

@Component({
    selector: "store-movie-list",
    templateUrl: "movieList.component.html"
})
export class MovieListComponent {
    constructor(private repo: Repository) { }
    get movies(): Movie[] {
        return this.repo.movies;
    }
}
