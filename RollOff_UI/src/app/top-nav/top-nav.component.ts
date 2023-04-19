import { Component, OnInit } from '@angular/core';
import { EmployeeDetailsService } from 'src/app/Service/employee-details.service';

@Component({
  selector: 'app-top-nav',
  templateUrl: './top-nav.component.html',
  styleUrls: ['./top-nav.component.css']
})
export class TopNavComponent implements OnInit{
  user:any;
  Isloggedin:boolean = false;

  constructor(){}


  ngOnInit(): void {
  //  this.checkstorage();
  }
ngDoCheck(){
this.checkstorage();
}
  checkstorage()
  {
    this.user =localStorage.getItem('token');
    if(this.user!=null){
      this.Isloggedin =true;
    }
  }
  logout()
  {
    localStorage.clear();
    this.Isloggedin=false;
    console.log(this.Isloggedin);
  }
}
