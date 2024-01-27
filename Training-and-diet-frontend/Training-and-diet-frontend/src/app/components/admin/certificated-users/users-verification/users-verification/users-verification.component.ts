import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { error } from 'jquery';
import { forkJoin } from 'rxjs';
import { CertificateListVerification } from 'src/app/models/admin/certificate-list-verification.model';
import { UserInfoForVerification } from 'src/app/models/admin/user-info-for-verification.model';
import { UserVerifyPatch } from 'src/app/models/admin/user-verify-patch.model';
import { AdminService } from 'src/app/services/admin.service';
import { CertificateService } from 'src/app/services/certificate.service';
import { PreviousUrlService } from 'src/app/services/previous-url.service';

@Component({
  selector: 'app-users-verification',
  templateUrl: './users-verification.component.html',
  styleUrls: ['./users-verification.component.css']
})
export class UsersVerificationComponent implements OnInit {

  userId: string = '';
  user: UserInfoForVerification | undefined;
  certificates: CertificateListVerification[] | undefined;
  userVerifyInfo: UserVerifyPatch | undefined;
  successFlag: string = "";
  constructor(private adminService: AdminService, private route: ActivatedRoute, private certificateService: CertificateService, private urlService: PreviousUrlService, private router: Router) { }

  ngOnInit(): void {
    this.userId = this.route.snapshot.params['id'];
    
    forkJoin({
      userInfo: this.adminService.getUserInfoForVeryfication(this.userId),
      certificates: this.adminService.getUserCertificates(this.userId)
    })
    .subscribe({
      next: (res) => {
        this.user = res.userInfo;
        this.userVerifyInfo = {
          idRole: this.user.idRole,
          isAccepted: this.user.isAccepted
        };
        this.certificates = res.certificates;
      },
      error: (error) => {
        
      }
    });
    
  }

  back() {
    this.router.navigate([this.urlService.adminPanelUsersBack()]);
    }

    verifyUser() {
      if (this.userVerifyInfo && this.user) {
        const idRoleChanged = this.userVerifyInfo.idRole !== this.user.idRole;
        const isAcceptedChanged = this.userVerifyInfo.isAccepted !== this.user.isAccepted;
        if (idRoleChanged || isAcceptedChanged) {

          this.userVerifyInfo.isAccepted = this.userVerifyInfo.isAccepted == true ? true : false

          this.adminService.verifyUser(this.userId, this.userVerifyInfo).subscribe({
            next: () => {
              this.router.navigate([this.urlService.adminPanelUsersBack()]);
            },
            error: (error) => {
              this.successFlag = "error";
              this.showErrorPopup("error");
              console.error('Server response:', error.error);
              document.documentElement.scrollTop = 0;          
            }
          });
        }
      }
    }
    
    

    showErrorPopup(status: string) {
      if(status == "error"){
        setTimeout(() => this.successFlag="", 3000); 
      }
    
    }

    

}
