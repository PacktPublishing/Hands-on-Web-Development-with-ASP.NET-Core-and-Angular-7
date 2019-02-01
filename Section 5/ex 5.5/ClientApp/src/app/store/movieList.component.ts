import { Component } from "@angular/core";
import { Repository } from "../models/repository";
import { Movie } from "../models/movie.model";
import { Cart } from "../models/cart.model";

@Component({
    selector: "store-movie-list",
    templateUrl: "movieList.component.html"
})
export class MovieListComponent {
    constructor(private repo: Repository, private cart: Cart) { }
    get movies(): Movie[] {
        if (this.repo.movies != null && this.repo.movies.length > 0) {
            let pageIndex = (this.repo.pagination.currentPage - 1)
                * this.repo.pagination.moviesPerPage;
            return this.repo.movies.slice(pageIndex,
                pageIndex + this.repo.pagination.moviesPerPage);
        }
    }
    addToCart(movie: Movie) {
        this.cart.addMovie(movie);
    }
}
