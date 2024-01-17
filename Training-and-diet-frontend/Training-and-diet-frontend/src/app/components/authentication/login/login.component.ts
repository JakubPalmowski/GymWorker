import { Component } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { Login } from 'src/app/models/login';

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

  constructor(private authenticationService:AuthenticationService) {}


  login(){
    console.log("login");
    this.credentialsIncorrect=false;
    
    this.authenticationService.login(this.loginRequest).subscribe({
      next:(response)=>{
        console.log(response);
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
