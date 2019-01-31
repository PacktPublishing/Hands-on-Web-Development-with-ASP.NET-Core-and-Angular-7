import { Studio } from "./studio.model";
import { Rating } from "./rating.model";

export class Movie {
	constructor(
		public movieId?: number,
		public image?: string,
    	public name?: string,
    	public category?: string,
    	public description?: string,
    	public price?: number,
    	public studio?: Studio,
    	public ratings?: Rating[]) { }
}
