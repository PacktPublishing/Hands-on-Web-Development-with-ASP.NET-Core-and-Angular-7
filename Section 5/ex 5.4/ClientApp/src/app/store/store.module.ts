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


@NgModule({
    declarations: [CartSummaryComponent, CategoryFilterComponent,
        PaginationComponent, MovieListComponent, RatingsComponent,
        MovieSelectionComponent,CartDetailComponent],
    imports: [BrowserModule,RouterModule,FormsModule],
    exports: [MovieSelectionComponent]
})
export class StoreModule { }