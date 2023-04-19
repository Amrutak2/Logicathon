import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeesComponent } from './employees/employees.component';
import { ViewEmployeeComponent } from './view-employee/view-employee.component';
import { FeedbackFormComponent } from './feedback-form/feedback-form.component';
import { LoginComponent } from './login/login/login.component';
import { AuthGuardService } from './Service/auth-guard.service';
import { TempComponent } from './temp/temp.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  {
    path:'',
    component:LoginComponent
  },
  {
    path:'app-employees',
    component:EmployeesComponent,
    canActivate:[AuthGuardService]
  },
  {
    path:'app-register',
    component:RegisterComponent
  },
  {
    path:'app-employees',
    component:EmployeesComponent
  },
  {
    path:'app-temp',
    component:TempComponent
  },
  {
    path:'app-employees/:id',
    component:ViewEmployeeComponent
  },
  {
    path: 'app-login',
    component: LoginComponent
  },
{
  path:'feedback-form/:id',
    component:FeedbackFormComponent
},

// {
//   path:'', redirectTo: 'app-employees/:id', pathMatch: 'full'
// }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
