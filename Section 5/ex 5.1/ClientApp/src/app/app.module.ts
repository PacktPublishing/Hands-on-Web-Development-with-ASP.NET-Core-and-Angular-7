import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { ModelModule } from "./models/model.module";
import { RoutingConfig } from "./app.routing";
import { StoreModule } from "./store/store.module";
import { MovieSelectionComponent } from "./store/movieSelection.component";


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    RoutingConfig,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ModelModule,
    FormsModule,
    StoreModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
