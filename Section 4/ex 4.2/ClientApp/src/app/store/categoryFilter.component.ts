import { Component } from "@angular/core";
import { Repository } from "../models/repository";

@Component({
    selector: "store-categoryfilter",
    templateUrl: "categoryFilter.component.html"
})
export class CategoryFilterComponent {
    constructor(private repo: Repository) { }
}
