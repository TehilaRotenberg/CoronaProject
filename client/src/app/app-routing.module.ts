import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonalDitailsComponent } from './Components/personal-ditails/personal-ditails.component';
import { HomePageComponent } from './Components/home-page/home-page.component';
const routes: Routes = [{path:"app-personal-ditails",component:PersonalDitailsComponent},{path:"app-home-page",component:HomePageComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
