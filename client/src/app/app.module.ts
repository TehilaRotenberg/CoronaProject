import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomePageComponent } from './Components/home-page/home-page.component';

import { HttpClientModule, HttpClient } from '@angular/common/http';
import { PersonalDitailsComponent } from './Components/personal-ditails/personal-ditails.component';
@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    PersonalDitailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
