import { Component, ViewChild } from '@angular/core';
import { NgForm, NgModel } from '@angular/forms';
import { Router } from '@angular/router';
import { CertificateCreate } from 'src/app/models/certificate/certificateCreate';
import { CertificateService } from 'src/app/services/certificate.service';

@Component({
  selector: 'app-create-certificate',
  templateUrl: './create-certificate.component.html',
  styleUrls: ['./create-certificate.component.css']
})
export class CreateCertificateComponent {
  
  certificate: CertificateCreate = {
    description: "",
    pdfFile: null
  }
  @ViewChild('profileForm') profileForm: NgForm | undefined;
  fieldErrors: { [key: string]: string[] } = {};
  errorFlag: string = "";
  submitted: boolean = false;
  errorFile:string="";


  constructor(private certificateService: CertificateService, private router: Router) {
  }

  onSubmit() {
    this.submitted = true;
    if(this.certificate.pdfFile==null){
      this.errorFile="Nie wybrano pliku";
    }
    if (this.profileForm?.valid && this.errorFile=="") {
      this.certificateService.addCertificate(this.certificate).subscribe({
        next: (response) => {
        this.router.navigate(['/myProfile']);
        },
        error: (error) => {
          if (error.status === 400) {
           const { errors } = error.error;
  
           this.fieldErrors = {}; 
       
           for (const key in errors) {
               if (errors.hasOwnProperty(key)) {
                   this.fieldErrors[key] = errors[key]; 
               }
           }
           

          } else {
            this.errorFlag = "error";
            this.showErrorPopup(this.errorFlag);
            document.documentElement.scrollTop = 0;
            console.log(error);
          }
        }
      });
    }
    }

    showErrorPopup(status: string) {
      if(status == "error"){
        setTimeout(() => this.errorFlag="", 3000); 
      }
    
    }

    // Komponent TypeScript
onFileSelected(event: Event): void {
  const element = event.target as HTMLInputElement;
  const file = element.files ? element.files[0] : null;

  if (file) {
    this.certificate.pdfFile = file;
    this.errorFile="";


    if (file.type !== 'application/pdf') {
      this.errorFile="Plik musi być w formacie pdf";
      return;
    } else if (file.size > 1048576) {
      this.errorFile="Plik nie może być większy niż 1MB";
      return;
    }
  } else {
    this.errorFile="Nie wybrano pliku";
  }
}


 


}
