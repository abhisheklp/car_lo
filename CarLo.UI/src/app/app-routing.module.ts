import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { CarsComponent } from './cars/cars.component';
import { CarDetailsComponent } from './car-details/car-details.component';
import { CarRentalAgreementsComponent } from './car-rental-agreements/car-rental-agreements.component';
import { AddCarComponent } from './add-car/add-car.component';
import { UpdateCarComponent } from './update-car/update-car.component';
import { ReturnApprovalComponent } from './return-approval/return-approval.component';

const routes: Routes = [
  { path : '', component : HomeComponent },
  { path : 'cars', component : CarsComponent },
  { path : 'cars/car-details/:id', component : CarDetailsComponent},
  { path : 'cars/add-car', component : AddCarComponent},
  { path : 'cars/update-car/:id', component : UpdateCarComponent},
  { path : 'rental-agreements', component : CarRentalAgreementsComponent},
  { path : 'return-approval', component : ReturnApprovalComponent },
  { path : 'login', component : LoginComponent},
  { path : 'signup', component : SignupComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
