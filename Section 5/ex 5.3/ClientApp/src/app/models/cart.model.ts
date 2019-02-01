import { Injectable } from "@angular/core";
import { Movie } from "./movie.model";

@Injectable()
export class Cart {
    selections: MovieSelection[] = [];
    itemCount: number = 0;
    totalPrice: number = 0;
    //---------------------------------------------------
    addMovie(movie: Movie) {
        let selection = this.selections
            .find(ps => ps.movieId == movie.movieId);
        if (selection) {
            selection.quantity++;
        } else {
            this.selections.push(new MovieSelection(this,
                movie.movieId, movie.name,
                movie.price, 1));
        }
        this.update();
    }
    //---------------------------------------------------
    updateQuantity(movieId: number, quantity: number) {
        if (quantity > 0) {
            let selection = this.selections.find(ps => ps.movieId == movieId);
            if (selection) {
                selection.quantity = quantity;
            }
        } else {
            let index = this.selections.findIndex(ps => ps.movieId == movieId);
            if (index != -1) {
                this.selections.splice(index, 1);
            }
            this.update();
        }
    }
    //---------------------------------------------------
    clear() {
        this.selections = [];
        this.update();
    }
    //---------------------------------------------------
    update() {
        this.itemCount = this.selections.map(ps => ps.quantity)
            .reduce((prev, curr) => prev + curr, 0);
        this.totalPrice = this.selections.map(ps => ps.price * ps.quantity)
            .reduce((prev, curr) => prev + curr, 0);
    }
}
//---------------------------------------------------
export class MovieSelection {
    constructor(public cart: Cart,
        public movieId?: number,
        public name?: string,
        public price?: number,
        private quantityValue?: number) { }
    get quantity() {
        return this.quantityValue;
    }
    set quantity(newQuantity: number) {
        this.quantityValue = newQuantity;
        this.cart.update();
    }
}
