import { Injectable } from "@angular/core";
import { Cart } from "./cart.model";
import { Repository } from "./repository";
 
@Injectable()
export class Order {
    constructor(private repo: Repository, public cart: Cart) { }
	orderId: number;
	name: string;
	address: string;
	payment: Payment = new Payment();
    submitted: boolean = false;
	shipped: boolean = false;
    orderConfirmation: OrderConfirmation;
	get movies(): CartLine[] {
        return this.cart.selections
            .map(p => new CartLine(p.movieId, p.quantity));
	} clear() {
        this.name = null;
        this.address = null;
        this.payment = new Payment();
    	this.cart.clear();
        this.submitted = false;
	}
	submit() {
        this.submitted = true;
        this.repo.createOrder(this);
	}
}
export class Payment {
    cardNumber: string;
    cardExpiry: string;
    cardSecurityCode: string;
}
export class CartLine {
    constructor(private movieId: number,
        private quantity: number) { }
}
export class OrderConfirmation {
    constructor(public orderId: number,
        public authCode: string,
    	public amount: number) { }
}
