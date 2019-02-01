import { Component } from "@angular/core";
import { Repository } from "../models/repository";
import { Movie } from "../models/movie.model";
import { Studio } from "../models/studio.model";

@Component({
   templateUrl: "movieAdmin.component.html"
})
export class MovieAdminComponent {
   constructor(private repo: Repository) { }
   tableMode: boolean = true;
   get movie(): Movie {
       return this.repo.movie;
   }
   selectMovie(id: number) {
       this.repo.getMovie(id);
   }
   saveMovie() {
       if (this.repo.movie.movieId == null) {
           this.repo.createMovie(this.repo.movie);
       } else {
           this.repo.replaceMovie(this.repo.movie);
       }
       this.clearMovie()
       this.tableMode = true;
   }
   deleteMovie(id: number) {
       this.repo.deleteMovie(id);
   }
   clearMovie() {
       this.repo.movie = new Movie();
       this.tableMode = true;
   }
   get movies(): Movie[] {
       return this.repo.movies;
   }
}
