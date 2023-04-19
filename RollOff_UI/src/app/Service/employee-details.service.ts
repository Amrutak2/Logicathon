import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
//import{GetAllEmployeeResponse} from '../Models/api-models/getallstudentresponse.models'
import {Employee} from '../Models/api-models/Employee.models';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class EmployeeDetailsService {
  private isLoggedIn = new BehaviorSubject<boolean>(false);

  public isLoggedIn$ = this.isLoggedIn.asObservable();
  baseApiUrl:string=environment.baseApiUrl;
  constructor(private httpClient:HttpClient) { }

  getEmployee():Observable<Employee[]>{
    return this.httpClient.get<Employee[]>(this.baseApiUrl+'Employees');
  }

  getEmployeebyid(employeeid:string):Observable<Employee>{
    return this.httpClient.get<Employee>(this.baseApiUrl+'Employees/'+employeeid);
  }
 // constructor(private http:HttpClient) { }

 saveFormData(data:any){
  console.log(data);
  return this.httpClient.post(this.baseApiUrl+'Form',data);
}
  //baseServerUrl = "https://localhost:44385/";

  registerUser(user: any){
    // console.log(user);
   return this.httpClient.post(this.baseApiUrl + "api/Register",
   {
    Username:user[0],
    Email :user[1],
    Password :user[2],
    Department: user[3],
   },
   {
    responseType:'text',
   });
  }
 
  login(model: any){
    return this.httpClient.post(
      this.baseApiUrl + "api/Auth/Login",model);
    }

   loggedIn(){
       return !! localStorage.getItem('token')
    }

    UserLogin(){
      
    }
}
