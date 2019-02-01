import { Component } from "@angular/core";
import { Repository } from "../models/repository";
import { Movie } from "../models/movie.model";
import { Studio } from "../models/studio.model";

@Component({
    selector: "admin-movie-editor",
    templateUrl: "movieEditor.component.html"
})
export class MovieEditorComponent {
    constructor(private repo: Repository) { }
    get movie(): Movie {
        return this.repo.movie;
    }
    get studios(): Studio[] {
        return this.repo.studios;
    }
    compareStudios(s1: Studio, s2: Studio) {
        return s1 && s2 && s1.name == s2.name;
    }
}
