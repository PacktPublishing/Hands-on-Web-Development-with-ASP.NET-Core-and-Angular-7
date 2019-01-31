import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { ModelModule } from "./models/model.module";
import { MovieTableComponent } from "./structure/movieTable.component"
import { CategoryFilterComponent } from "./structure/categoryFilter.component"


@NgModule({
  declarations: [
    MovieTableComponent, 
    CategoryFilterComponent,
    AppComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ModelModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
