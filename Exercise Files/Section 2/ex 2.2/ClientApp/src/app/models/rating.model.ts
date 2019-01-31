import { Movie } from "./movie.model";
 
export class Rating {
	constructor(
	public ratingId?: number,
	public stars?: number,
	public movie?: Movie) { }
	}
