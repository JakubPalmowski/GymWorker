import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ExercisesListComponent } from './components/exercises/exercises-list/exercises-list.component';
import { TrainingPlansListComponent } from './components/traininig-plans/training-plans-list/training-plans-list.component';
import { AddTrainingPlanComponent } from './components/traininig-plans/add-training-plan/add-training-plan.component';
import { EditTrainingPlanComponent } from './components/traininig-plans/edit-training-plan/edit-training-plan.component';
import { NewTrainingExerciseComponent } from './components/exercises/new-training-exercise/new-training-exercise.component';
import { LoginComponent } from './components/authentication/login/login.component';
import { PasswordRecoveryComponent } from './components/authentication/password-recovery/password-recovery.component';
import { RegisterComponent } from './components/authentication/register/register.component';
import { TrainerListComponent } from './components/mentorsLists/trainer-list/trainer-list.component';
import { DieteticianListComponent } from './components/mentorsLists/dietetician-list/dietetician-list.component';
import { TrainerProfileComponent } from './components/mentorsLists/trainer-profile/trainer-profile.component';


const routes: Routes = [
  {
    path: 'training-plans',
    component: TrainingPlansListComponent
  },
  {
    path: 'training-plans/add',
    component: AddTrainingPlanComponent
  },
  {
    path: 'training-plans/edit/:id',
    component: EditTrainingPlanComponent
  },
  {
    path: 'exercises-list',
    component: ExercisesListComponent
  },
  {
    path: 'training-exercise/add',
    component: NewTrainingExerciseComponent
  }, 
  {path: '', component: LoginComponent},
  {path: 'PasswordRecovery', component: PasswordRecoveryComponent},
  {path:'Register', component: RegisterComponent},
  {path: 'TrainersList', component: TrainerListComponent},
  {path: 'DieteticiansList', component: DieteticianListComponent},
  {path: 'TrainerProfile', component: TrainerProfileComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
