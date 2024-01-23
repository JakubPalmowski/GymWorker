import { Component, OnInit } from '@angular/core';
import { ExerciseShort } from 'src/app/models/exercise-short.model';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-exercise-list-admin',
  templateUrl: './exercise-list-admin.component.html',
  styleUrls: ['./exercise-list-admin.component.css']
})
export class ExerciseListAdminComponent implements OnInit {
    
      exercices: ExerciseShort[] | undefined;
      searchTerm: string = '';
      filteredExercices: ExerciseShort[] | undefined;
      error:boolean = false;
      showDialog: boolean = false;
      selectedExercise: ExerciseShort | null = null;
    
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

      deleteExercise(exerciseId: number) {
        this.selectedExercise = this.filteredExercices?.find(e => e.idExercise === exerciseId) ?? null;
        if (this.selectedExercise) {
          this.showDialog = true;
        } else {
          alert('Siłownia nie została znaleziona.'); 
        }
      }
    
      confirmDelete() {
        if (this.selectedExercise) {
          this.adminService.deleteAdminExercise(this.selectedExercise.idExercise.toString()).subscribe({
            next: () => {
              this.ngOnInit(); 
            },
            error: (error) => {
              alert('Wystąpił błąd podczas usuwania siłowni.');
            }
          });
          this.showDialog = false; 
        }
      }
    
      cancelDelete() {
        this.showDialog = false; 
      }
    
    
    
    }
