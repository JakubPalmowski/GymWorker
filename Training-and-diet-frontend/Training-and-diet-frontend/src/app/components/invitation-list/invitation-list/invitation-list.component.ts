import { Component, OnInit } from '@angular/core';
import { forkJoin, of, switchMap } from 'rxjs';
import { Invitation } from 'src/app/models/mentor-pupil/invitation.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { FileService } from 'src/app/services/file.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-invitation-list',
  templateUrl: './invitation-list.component.html',
  styleUrls: ['./invitation-list.component.css']
})
export class InvitationListComponent implements OnInit{



showDialog: boolean = false;
showDialogAdd: boolean = false;
selectedInvitation: Invitation | null = null;
  invitations: Invitation[] | undefined;
constructor(private userService: UserService, private fileService: FileService, private authService: AuthenticationService){

}

ngOnInit(): void {
  this.userService.getMentorInvitations().pipe(
    switchMap((invitations) => {
      this.invitations = invitations;

      if (invitations.length === 0) {
        return of([]);
      }

      const imageRequests = invitations.map(invitation => {
        if (invitation.imageUri) {

          return this.fileService.getFile(invitation.imageUri).pipe(
            switchMap((imageSrc) => {
 
              invitation.imageSrc = URL.createObjectURL(imageSrc); 
              return of(invitation); 
            })
          );
        } else {
   
          invitation.imageSrc = 'assets/images/user.png';
          return of(invitation); 
        }
      });
      return forkJoin(imageRequests);
    })
  ).subscribe();
}

deleteInvitation(id: number) {
  this.selectedInvitation = this.invitations?.find(e => e.idUser === id) ?? null;
        if (this.selectedInvitation) {
          this.showDialog = true;
        } else {
          alert('Zaproszenie nie zostało znalezione.'); 
        }
    
}



confirmDelete() {
  if (this.selectedInvitation) {
    this.userService.deleteInvitation(this.selectedInvitation.idUser.toString()).subscribe({
      next: () => {
        this.ngOnInit(); 
      },
      error: (error) => {
        alert('Wystąpił błąd podczas usuwania zaproszenia.');
      }
    });
    this.showDialog = false; 
  }
}

cancelDelete() {
  this.showDialog = false; 
}

acceptInvitation(id: number) {
  this.selectedInvitation = this.invitations?.find(e => e.idUser === id) ?? null;
  if (this.selectedInvitation) {
    this.showDialogAdd = true;
  } else {
    alert('Zaproszenie nie zostało znalezione.'); 
  }
}

cancelAccept() {
  this.showDialogAdd = false; 
}

confirmAccept() {
  if (this.selectedInvitation) {
    this.userService.acceptInvitation(this.selectedInvitation.idUser.toString()).subscribe({
      next: () => {
        this.ngOnInit(); 
      },
      error: (error) => {
        alert('Wystąpił błąd podczas akceptowania zaproszenia.');
      }
    });
    this.showDialogAdd = false; 
  }
}


}
