import { Component } from "@angular/core";
import { Repository } from "../models/repository";

@Component({
    templateUrl: "admin.component.html"
})
export class AdminComponent {
    constructor(private repo: Repository) {
        repo.filter.reset();
        repo.filter.related = true;
        this.repo.getMovies();
        this.repo.getStudios();
        this.repo.getOrders();
    }
}
