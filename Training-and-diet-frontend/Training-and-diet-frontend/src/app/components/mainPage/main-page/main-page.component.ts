import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit{

  role?:string='';


  constructor(private authenticationService:AuthenticationService, private router:Router) { }

  ngOnInit(): void {
    this.role=this.authenticationService.getRole();
    //console.log(this.authenticationService.isTokenExpired());
  //  console.log(this.authenticationService.getRole());
   // console.log(localStorage.getItem('acessToken'));

    if(this.authenticationService.getRole()==undefined){
      this.router.navigateByUrl('/login');
      console.log("");
    }


  }


}
