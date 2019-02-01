import { Component } from '@angular/core';
import { Repository } from "../models/repository";
import { Movie } from "../models/movie.model";
import { Router } from "@angular/router";

@Component({
    selector: "movie-table",
    templateUrl: "./movieTable.component.html"
})
export class MovieTableComponent {
    constructor(private repo: Repository, private router: Router) { }
    get movies(): Movie[] {
        return this.repo.movies;
    }
    selectMovie(id: number) {
        this.repo.getMovie(id);
        this.router.navigateByUrl("/detail");
    }
}
