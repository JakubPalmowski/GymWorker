import { Component } from '@angular/core';
import { registerAdditionalFields } from 'src/app/models/others/register-additional-fields.model';
import { Register } from 'src/app/models/authentication/register.model';
import { Form } from '@angular/forms';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  submitted=false;
  emailTaken=false;

  registerRequest: Register={
    name:'',
    lastName:'',
    email:'',
    password:'',
    phoneNumber:'',
    roleId:2
  }

  additionalFields:registerAdditionalFields={
    passwordRepeat:'',
    policyCheckbox:false
  }

  /**
   *
   */
  constructor(private authenticationService:AuthenticationService,private router:Router) {}


  register(){
    console.log("register");
    this.emailTaken=false;
    this.authenticationService.register(this.registerRequest).subscribe({
      next:(response)=>{
        console.log(response);
        this.authenticationService.setSession(response);
        this.router.navigateByUrl('');
        
      },
      error:(response)=>{

        if(response.status==409){
          this.emailTaken=true;
          console.log("email taken");
        }
      }
    }
    );
    
  }

  onSubmit(valid:any){
    this.submitted=true;
  
    if(valid){
      this.register();
      
    }
    
  }
}
