import { Component, OnInit } from '@angular/core';
import { forkJoin, of, switchMap } from 'rxjs';
import { Invitation } from 'src/app/models/invitation';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { FileService } from 'src/app/services/file.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-invitation-list',
  templateUrl: './invitation-list.component.html',
  styleUrls: ['./invitation-list.component.css']
})
export class InvitationListComponent implements OnInit{

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
          // Pobierz obrazek, jeśli imageUri istnieje.
          return this.fileService.getFile(invitation.imageUri).pipe(
            switchMap((imageSrc) => {
              // Przypisz bezpośrednio URL do obrazka.
              invitation.imageSrc = URL.createObjectURL(imageSrc); 
              return of(invitation); // Zwróć zmodyfikowane zaproszenie.
            })
          );
        } else {
          // Użyj domyślnego obrazka, jeśli imageUri jest null.
          invitation.imageSrc = 'assets/default-image.png';
          return of(invitation); // Zwróć zaproszenie z domyślnym obrazkiem.
        }
      });

      return forkJoin(imageRequests);
    })
  ).subscribe(
    () => {
      console.log('Wszystkie zaproszenia i obrazy zostały załadowane.');
    },
    (error) => {
      console.error('Wystąpił błąd podczas pobierania zaproszeń lub obrazów', error);
    }
  );
}

}
