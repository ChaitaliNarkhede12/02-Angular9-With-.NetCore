import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'
import { HomeComponent } from '../home/home.component';
import { EmployeeService } from '../service/employee.service';

import { HomeRoutingModule } from '../../app/home/home-routing.module';

//import { MatFormFieldModule } from '@angular/material/form-field';
//import { MatInputModule } from '@angular/material/input';

@NgModule({
  declarations: [
    HomeComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    HomeRoutingModule,
   // MatFormFieldModule,
   // MatInputModule
  ],
  providers: [
    EmployeeService
  ],
  bootstrap: [HomeComponent]
})
export class HomeModule { }
