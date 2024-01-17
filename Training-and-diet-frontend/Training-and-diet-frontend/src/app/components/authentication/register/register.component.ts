import { Component } from '@angular/core';
import { registerAdditionalFields } from 'src/app/models/registerAdditionalFields';
import { Register } from 'src/app/models/register';
import { Form } from '@angular/forms';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  submitted=false;

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
  constructor(private authenticationService:AuthenticationService) {}


  register(){
    console.log("register");
    this.authenticationService.register(this.registerRequest).subscribe({
      next:(response)=>{
        console.log(response);
      },
      error:(response)=>{
        console.log(response);
      }
    }
);
    
  }

  onSubmit(valid:any){
    this.submitted=true;
  
    if(valid){
      console.log(this.registerRequest.email);
      console.log(this.submitted);
      this.register();
      
    }
    
  }
}
