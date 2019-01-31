import { Movie } from "./movie.model";
import { HttpClient } from '@angular/common/http'; 
import { Inject, Injectable } from '@angular/core'; 
 
const moviesUrl = "/api/movies";
@Injectable()
export class Repository {
 
	public movie: Movie;
	constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    	http.get<Movie>(baseUrl + 'api/movies/GetMovie')
		.subscribe(result => {
		this.movie = result;
		},
			error => console.error(error));

			this.getMovie(3);
	}
	getMovie(id: number) {
		//console.log("Movie Data Requested");
		this.http.get(moviesUrl + "/" + id)
				 .subscribe(response => { this.movie = response });
	}

}
