import { Component } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { Login } from 'src/app/models/authentication/login.model';
import { Router } from '@angular/router';
import { PreviousUrlService } from 'src/app/services/previous-url.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  loginRequest:Login={
    email:'',
    password:''
  };

  credentialsIncorrect=false;
  submitted=false;

  constructor(private authenticationService:AuthenticationService,private router:Router) {}


  login(){
    this.credentialsIncorrect=false;
    
    this.authenticationService.login(this.loginRequest).subscribe({
      next:(response)=>{
        this.authenticationService.setSession(response);
        this.router.navigateByUrl('/');
      },
      error:(response)=>{

        if(response.status==401){
          this.credentialsIncorrect=true;
          
        }
      }
    }
    );
    
    
  }

  onSubmit(valid:any){
   this.submitted=true;
   if(valid){
   this.login();
   }
    
  }
}
