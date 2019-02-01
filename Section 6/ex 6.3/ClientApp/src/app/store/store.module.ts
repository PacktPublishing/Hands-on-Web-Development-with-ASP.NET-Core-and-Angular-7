import { NgModule } from "@angular/core";
import { BrowserModule } from '@angular/platform-browser';
import { CartSummaryComponent } from "./cartSummary.component";
import { CategoryFilterComponent } from "./categoryFilter.component";
import { PaginationComponent } from "./pagination.component";
import { MovieListComponent } from "./movieList.component";
import { RatingsComponent } from "./ratings.component";
import { MovieSelectionComponent } from "./movieSelection.component";
import { CartDetailComponent } from "./cartDetail.component";
import { RouterModule } from "@angular/router";
import { FormsModule } from "@angular/forms";
import { CheckoutDetailsComponent } from "./checkout/checkoutDetails.component";
import { CheckoutPaymentComponent } from "./checkout/checkoutPayment.component";
import { CheckoutSummaryComponent } from "./checkout/checkoutSummary.component";
import { OrderConfirmationComponent } from "./checkout/orderConfirmation.component";


@NgModule({
    declarations: [CartSummaryComponent, CategoryFilterComponent,
        PaginationComponent, MovieListComponent, RatingsComponent,
        MovieSelectionComponent,CartDetailComponent,
        CheckoutDetailsComponent, CheckoutPaymentComponent,
        CheckoutSummaryComponent, OrderConfirmationComponent],
    imports: [BrowserModule,RouterModule,FormsModule],
    exports: [MovieSelectionComponent]
})
export class StoreModule { }