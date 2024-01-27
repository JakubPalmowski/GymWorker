import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route } from '@angular/router';
import { of, switchMap } from 'rxjs';
import { CertificatedUsersList } from 'src/app/models/admin/certificated-users-list.model';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-certificated-users-list',
  templateUrl: './certificated-users-list.component.html',
  styleUrls: ['./certificated-users-list.component.css']
})
export class CertificatedUsersListComponent implements OnInit{

  constructor(private adminService: AdminService, private route: ActivatedRoute) { }


  status: string = '';
  users: CertificatedUsersList[] | undefined;
  searchTerm: string = '';
  filteredUsers: CertificatedUsersList[] | undefined;
  error:boolean = false;

  ngOnInit(): void {
    this.route.paramMap.pipe(
      switchMap(params => {
        this.status = params.get('status') ?? '';
        if (!(this.status === 'Pending' || this.status === 'Accepted')) {
          this.error = true;
          return of(null);  
        }
        if (this.status === 'Pending') {
          return this.adminService.getAllUsersWithPendingCertificates();
        }
        if (this.status === 'Accepted') {
          return this.adminService.getAllUsersWithAcceptedCertificates();
        }
        return of(null);  
      })
    ).subscribe({
      next: users => {
        if (users) {  
          this.users = users;
          this.filteredUsers = users;
          this.filterUser();  
        } else {
          
        }
      },
      error: err => {

      }
    });
  }
  
  filterUser() {
    if (!this.searchTerm) {
      this.filteredUsers = this.users; 
    } else {
      this.filteredUsers = this.users?.filter(user =>
        user.name.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
        user.lastName.toLowerCase().includes(this.searchTerm.toLowerCase())
      );
    }
  }

}
