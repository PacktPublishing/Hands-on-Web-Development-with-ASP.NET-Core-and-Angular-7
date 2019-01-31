import { Movie } from "./movie.model";
import { HttpClient } from '@angular/common/http'; // added
import { Inject, Injectable } from '@angular/core'; // added
 
@Injectable()
export class Repository {
 
	public movie: Movie;
	constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    	http
        	.get<Movie>(baseUrl + 'api/SampleData/GetMovie')
        	.subscribe(result => {
                this.movie = result;
        	},
  	          error => console.error(error));
	}
}
