import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ExercisesListComponent } from './components/exercises/exercises-list/exercises-list.component';
import { TrainingPlansListComponent } from './components/traininig-plans/training-plans-list/training-plans-list.component';


const routes: Routes = [
  {
    path: 'training-plans',
    component: TrainingPlansListComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
