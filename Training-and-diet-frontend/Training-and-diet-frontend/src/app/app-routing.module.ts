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
import { MentorsListComponent } from './components/mentors-list/mentors-list.component';
import { MentorProfileComponent } from './components/mentor-profile/mentor-profile.component';
import { ExercisesEditComponent } from './components/exercises/exercises-edit/exercises-edit.component';
import { ExercisesAddComponent } from './components/exercises/exercises-add/exercises-add.component';
import { ExercisesDetailsComponent } from './components/exercises/exercises-details/exercises-details.component';
import { MealsListComponent } from './components/meals/meals-list/meals-list.component';
import { MealsAddComponent } from './components/meals/meals-add/meals-add.component';
import { MealsEditComponent } from './components/meals/meals-edit/meals-edit.component';
import { MealsDetailsComponent } from './components/meals/meals-details/meals-details.component';


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
    path: 'exercises/edit/:id',
    component: ExercisesEditComponent
  },
  {
    path: 'exercises/add',
    component: ExercisesAddComponent
  },
  {
    path: 'exercises/details/:id',
    component: ExercisesDetailsComponent
  },
  {
    path: 'training-exercise/add',
    component: NewTrainingExerciseComponent
  }, 
  {
    path: 'meals-list',
    component: MealsListComponent
  }, 
  {
    path: 'meals/add',
    component: MealsAddComponent
  }, 
  {
    path: 'meals/edit/:id',
    component: MealsEditComponent
  }, 
  {
    path: 'meals/details/:id',
    component: MealsDetailsComponent
  }, 
  {path: '', component: LoginComponent},
  {path: 'passwordRecovery', component: PasswordRecoveryComponent},
  {path:'register', component: RegisterComponent},
  {path: 'trainersList', component: MentorsListComponent},
  {path: 'dieticiansList', component: MentorsListComponent},
  {path: 'trainerProfile/:id', component: MentorProfileComponent},
  {path: 'dieticianProfile/:id', component: MentorProfileComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
