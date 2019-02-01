import { NgModule } from "@angular/core";
import { Repository } from "./repository";
import { Cart } from "./cart.model";

 @NgModule({
	providers: [Repository, Cart]
})
export class ModelModule { }
