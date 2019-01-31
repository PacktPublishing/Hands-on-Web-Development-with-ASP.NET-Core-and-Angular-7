import { Routes, RouterModule } from "@angular/router";
import { MovieTableComponent } from "./structure/movieTable.component"
import { MovieDetailComponent } from "./structure/movieDetail.component";

const routes: Routes = [
    { path: "table", component: MovieTableComponent },
    { path: "detail", component: MovieDetailComponent },
    { path: "", component: MovieTableComponent }]
   
export const RoutingConfig = RouterModule.forRoot(routes);
   