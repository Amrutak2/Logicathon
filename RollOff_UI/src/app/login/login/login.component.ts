import { Component, OnInit, } from '@angular/core';
import { FormControl, FormGroup,Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { FloatLabelType } from '@angular/material/form-field';
import { Router } from '@angular/router';
import { EmployeeDetailsService } from 'src/app/Service/employee-details.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']})

export class LoginComponent implements OnInit
{
  model:any = {};
  responsedata:any;
  Isloggedin = false;
  Role : any = ["Admin","Accounts","PSP"]

  //isUserValid: boolean | undefined;
  hide = true;
  floatLabelControl = new FormControl('auto' as FloatLabelType);

  constructor(private loginAuth: EmployeeDetailsService, private _router: Router) {}

  loginUser(){
    this.loginAuth.login(this.loginForm.value).subscribe({

      next: response=>{
        console.log(response);
        if(response!=null){
          this.responsedata = response;
          localStorage.setItem('token',this.responsedata.result);
          localStorage.setItem('role',JSON.stringify(this.loginForm.value.department));
          if(this.loginForm.value.department== 'Accounts'){
           // this._router.navigate(["app-employees"])window.location.reload();

            this._router.navigate(['app-employees'])
          }
        }
        this.Isloggedin = true;
      }
      // error: err=>{

      //   if(err.status==400){
      //     console.log("Invalid Details");
      //   }
      // }

    })
  }




// navigateToFirst() {
//   this._router.navigate(['app-employees'])
//   console.log(this.model);
// }
ngOnInit(): void {}

loginForm = new FormGroup({
  email :new FormControl("",[Validators.required,Validators.email]),
  password: new FormControl("",[Validators.required,Validators.minLength(6), Validators.maxLength(15)]),
  department: new FormControl(''),
});



    get Email() :FormControl{
      return this.loginForm.get('email') as FormControl;
    }
    get Password():FormControl{
      return this.loginForm.get('password') as FormControl;
    }
    get Department():FormControl{
      return this.loginForm.get('department') as FormControl;
    }

    changeRole(e:any){
      console.log(e.target.value);
    }
  }
