import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { catchError, of, switchMap } from 'rxjs';
import { CertificateInfoForVeryfication } from 'src/app/models/admin/certificate-info-for-veryfication.model';
import { AdminService } from 'src/app/services/admin.service';
import { FileService } from 'src/app/services/file.service';
import { PreviousUrlService } from 'src/app/services/previous-url.service';

@Component({
  selector: 'app-certificate-verification',
  templateUrl: './certificate-verification.component.html',
  styleUrls: ['./certificate-verification.component.css']
})
export class CertificateVerificationComponent implements OnInit {

 certificate: CertificateInfoForVeryfication | undefined;
 idCertificate: string= '';
 successFlag: string = "";
 showDialog: boolean = false;

  constructor(private adminService: AdminService, private route: ActivatedRoute, private router: Router, private fileService: FileService, private prevoiousService: PreviousUrlService) {
    
  }
  
  ngOnInit(): void {
    this.idCertificate = this.route.snapshot.params['id'];
    
    this.adminService.getCertificateInfoForVeryfication(this.idCertificate).pipe(
      switchMap(data => {
        this.certificate = data;
        if (this.certificate && this.certificate.pdfUri) {
          return this.fileService.getFile(this.certificate.pdfUri);
        }
        return of(null); 
      }),
      catchError(error => {
        return of(null); 
      })
    ).subscribe(blob => {
      if (blob) {
        const objectUrl = URL.createObjectURL(blob);
        if (this.certificate){
        this.certificate.pdfUrl = objectUrl;
        }
      }
    });
}

back() {
  this.router.navigate([this.prevoiousService.getPreviousUrl()]);
  }

  acceptCertificate() {
    this.adminService.acceptCertificate(this.idCertificate).subscribe(
      {
        next: () => {
          this.router.navigate([this.prevoiousService.getPreviousUrl()]);
        },
        error: (response) => {
          this.successFlag = "error";
          this.showErrorPopup("error");
        }
      }
    );
    }

    showErrorPopup(status: string) {
      if(status == "error"){
        setTimeout(() => this.successFlag="", 3000); 
      }
    
    }

    deleteCertificate() {
      if(this.certificate){
        this.showDialog = true;
      }
    }

    confirmDelete() {
      if (this.certificate) {
        this.adminService.deleteCertificate(this.idCertificate).subscribe({
          next: () => {
            this.router.navigate([this.prevoiousService.getPreviousUrl()]);
          },
          error: (error) => {
            this.successFlag = "error";
            this.showErrorPopup("error");
          }
        });
        this.showDialog = false; 
      }
    }
  
    cancelDelete() {
      this.showDialog = false; 
    }
    

}
