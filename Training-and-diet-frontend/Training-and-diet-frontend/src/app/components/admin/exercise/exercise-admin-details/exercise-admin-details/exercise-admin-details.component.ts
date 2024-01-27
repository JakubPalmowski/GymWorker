import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ExerciseFull } from 'src/app/models/exercise/exercise-full.model';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-exercise-admin-details',
  templateUrl: './exercise-admin-details.component.html',
  styleUrls: ['./exercise-admin-details.component.css']
})
export class ExerciseAdminDetailsComponent implements OnInit {

  idExercise: string = '';
  exercise: ExerciseFull | undefined;

  constructor(private route: ActivatedRoute, private adminService: AdminService) {

    
  }


  ngOnInit(): void {
    this.idExercise = this.route.snapshot.params['id'];
    this.adminService.getAdminExerciseById(this.idExercise).subscribe({
      next: (response) => {
        this.exercise = response;
      },
      error: (error) => {
        
      }
    });

  }
}
