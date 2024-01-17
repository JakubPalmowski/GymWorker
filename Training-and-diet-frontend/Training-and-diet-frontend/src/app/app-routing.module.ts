import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ExercisesListComponent } from './components/exercises/exercises-list/exercises-list.component';
import { TrainingPlansListComponent } from './components/traininig-plans/training-plans-list/training-plans-list.component';
import { AddTrainingPlanComponent } from './components/traininig-plans/add-training-plan/add-training-plan.component';
import { EditTrainingPlanComponent } from './components/traininig-plans/edit-training-plan/edit-training-plan.component';
import { NewTrainingExerciseComponent } from './components/traininig-plans/new-training-exercise/new-training-exercise.component';
import { LoginComponent } from './components/authentication/login/login.component';
import { PasswordRecoveryComponent } from './components/authentication/password-recovery/password-recovery.component';
import { RegisterComponent } from './components/authentication/register/register.component';
import { MentorsListComponent } from './components/mentors-list/mentors-list.component';
import { MentorProfileComponent } from './components/mentor-profile/mentor-profile.component';
import { ExercisesEditComponent } from './components/exercises/exercises-edit/exercises-edit.component';
import { ExercisesAddComponent } from './components/exercises/exercises-add/exercises-add.component';
import { PupilProfileComponent } from './components/pupil-profile/pupil-profile.component';
import { ExercisesDetailsComponent } from './components/exercises/exercises-details/exercises-details.component';
import { MealsListComponent } from './components/meals/meals-list/meals-list.component';
import { MealsAddComponent } from './components/meals/meals-add/meals-add.component';
import { MealsEditComponent } from './components/meals/meals-edit/meals-edit.component';
import { MealsDetailsComponent } from './components/meals/meals-details/meals-details.component';
import { MyProfileComponent } from './components/myProfile/my-profile/my-profile.component';
import { MyProfileEditComponent } from './components/myProfile/my-profile-edit/my-profile-edit.component';
import { TrainingExerciseListComponent } from './components/traininig-plans/training-exercise-list/training-exercise-list.component';
import { EditTrainingExerciseComponent } from './components/traininig-plans/edit-training-exercise/edit-training-exercise.component';
import { PupilTrainingPlansListComponent } from './components/pupilTrainingPlan/pupil-training-plans-list/pupil-training-plans-list.component';
import { PupilTrainingPlanDetailsComponent } from './components/pupilTrainingPlan/pupil-training-plan-details/pupil-training-plan-details.component';
import { PupilTrainingExerciseDetailsComponent } from './components/pupilTrainingPlan/pupil-training-exercise-details/pupil-training-exercise-details.component';
import { CreateGymComponent } from './components/gym/create-gym/create-gym.component';


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
    path: 'exercises',
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
    path: 'training-plans/exercise-list/add',
    component: NewTrainingExerciseComponent
  }, 
  {
    path: 'training-plans/edit/:id/edit-training-exercise/:id',
    component: EditTrainingExerciseComponent
  }, 
  {
    path: 'training-plans/exercise-list',
    component: TrainingExerciseListComponent
  },
  {
    path: 'pupilTrainingPlans',
    component: PupilTrainingPlansListComponent
  },  
  {
    path: 'pupilTrainingPlans/details/:id',
    component: PupilTrainingPlanDetailsComponent
  },  
  {
    path: 'pupilTrainingPlans/details/:id/training-exercise-details/:id',
    component: PupilTrainingExerciseDetailsComponent
  },
  {
    path: 'meals',
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
  {path: 'dieticianProfile/:id', component: MentorProfileComponent},
  {path: 'pupilProfile/:id', component: PupilProfileComponent},
  {path: 'myProfile', component: MyProfileComponent},
  {path: 'myProfile/edit', component: MyProfileEditComponent},
  {path: 'createGym', component: CreateGymComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
