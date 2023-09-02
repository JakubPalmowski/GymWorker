import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ExercisesListComponent } from './components/exercises/exercises-list/exercises-list.component';
import { TrainingPlansListComponent } from './components/traininig-plans/training-plans-list/training-plans-list.component';
import { AddTrainingPlanComponent } from './components/traininig-plans/add-training-plan/add-training-plan.component';


const routes: Routes = [
  {
    path: 'training-plans',
    component: TrainingPlansListComponent
  },
  {
    path: 'training-plans/add',
    component: AddTrainingPlanComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
