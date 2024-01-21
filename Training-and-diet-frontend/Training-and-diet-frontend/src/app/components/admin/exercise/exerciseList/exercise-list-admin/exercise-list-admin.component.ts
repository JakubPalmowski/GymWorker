import { Component, OnInit } from '@angular/core';
import { ExerciseShort } from 'src/app/models/exercise-short.model';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-exercise-list-admin',
  templateUrl: './exercise-list-admin.component.html',
  styleUrls: ['./exercise-list-admin.component.css']
})
export class ExerciseListAdminComponent implements OnInit {

  deleteExercise(arg0: number) {
    throw new Error('Method not implemented.');
    }
    
      exercices: ExerciseShort[] | undefined;
      searchTerm: string = '';
      filteredExercices: ExerciseShort[] | undefined;
      error:boolean = false;
    
      constructor(private adminService: AdminService) { }
        
    
      ngOnInit(): void {
        this.adminService.getAdminExercises().subscribe({
          next: exercices => {
            this.exercices = exercices;
            this.filteredExercices = exercices;
            this.filterExercices();
          },
          error: err => {
            this.error = true;
          }
        });
      }
    
      filterExercices() {
        if (!this.searchTerm) {
          this.filteredExercices = this.exercices; 
        } else {
          this.filteredExercices = this.exercices?.filter(gym =>
            gym.name.toLowerCase().includes(this.searchTerm.toLowerCase())
          );
        }
      }
    
    
    
    }
