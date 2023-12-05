import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ViewCarPartComponent } from './view-car-part/view-car-part.component';
import { CreateCarPartComponent } from './create-car-part/create-car-part.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'carparts/:id', component: ViewCarPartComponent},
  {path: 'create', component: CreateCarPartComponent},
  {path: '**', component: HomeComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
