import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonalDitailsComponent } from './Components/personal-ditails/personal-ditails.component';
const routes: Routes = [{path:"app-personal-ditails",component:PersonalDitailsComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
