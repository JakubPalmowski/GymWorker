import { NgModule, inject } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ExercisesListComponent } from './components/exercises/exercises-list/exercises-list.component';
import { TrainingPlansListComponent } from './components/traininig-plans/training-plans-list/training-plans-list.component';
import { AddTrainingPlanComponent } from './components/traininig-plans/add-training-plan/add-training-plan.component';
import { EditTrainingPlanComponent } from './components/traininig-plans/edit-training-plan/edit-training-plan.component';
import { NewTrainingExerciseComponent } from './components/traininig-plans/new-training-exercise/new-training-exercise.component';
import { LoginComponent } from './components/authentication/login/login.component';
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
import { MyProfileComponent } from './components/my-profile/my-profile/my-profile.component';
import { MyProfileEditComponent } from './components/my-profile/my-profile-edit/my-profile-edit.component';
import { TrainingExerciseListComponent } from './components/traininig-plans/training-exercise-list/training-exercise-list.component';
import { EditTrainingExerciseComponent } from './components/traininig-plans/edit-training-exercise/edit-training-exercise.component';
import { PupilTrainingPlansListComponent } from './components/pupil-training-plan/pupil-training-plans-list/pupil-training-plans-list.component';
import { PupilTrainingPlanDetailsComponent } from './components/pupil-training-plan/pupil-training-plan-details/pupil-training-plan-details.component';
import { PupilTrainingExerciseDetailsComponent } from './components/pupil-training-plan/pupil-training-exercise-details/pupil-training-exercise-details.component';
import { CreateGymComponent } from './components/gym/create-gym/create-gym.component';
import { MainPageComponent } from './components/main-page/main-page/main-page.component';
import { GymListComponent } from './components/admin/gym/gym-list/gym-list/gym-list.component';
import { GymDetailsComponent } from './components/admin/gym/gym-details/gym-details/gym-details.component';
import { GymEditComponent } from './components/admin/gym/gym-edit/gym-edit/gym-edit.component';
import { GymVerificationComponent } from './components/admin/gym/gym-verification/gym-verification/gym-verification.component';
import { ExerciseListAdminComponent } from './components/admin/exercise/exercise-admin-list/exercise-list-admin/exercise-list-admin.component';
import { ExerciseCreateAdminComponent } from './components/admin/exercise/exercise-admin-create/exercise-create-admin/exercise-create-admin.component';
import { CreateCertificateComponent } from './components/certificate/create/create-certificate/create-certificate.component';
import { CertificatedUsersListComponent } from './components/admin/certificated-users/certificated-users-list/certificated-users-list/certificated-users-list.component';
import { UsersVerificationComponent } from './components/admin/certificated-users/users-verification/users-verification/users-verification.component';
import { CertificateVerificationComponent } from './components/admin/certificated-users/certificate-verification/certificate-verification/certificate-verification.component';
import { AssingPlanToPupilComponent } from './components/traininig-plans/assing-plan-to-pupil/assing-plan-to-pupil.component';
import { DietListComponent } from './components/diets/diet-list/diet-list.component';
import { AddDietComponent } from './components/diets/add-diet/add-diet.component';
import { EditDietComponent } from './components/diets/edit-diet/edit-diet.component';
import { EditDietMealComponent } from './components/diets/edit-diet-meal/edit-diet-meal.component';
import { DietMealsListComponent } from './components/diets/diet-meals-list/diet-meals-list.component';
import { NewDietMealComponent } from './components/diets/new-diet-meal/new-diet-meal.component';
import { AssignDietComponent } from './components/diets/assign-diet/assign-diet.component';
import { ExerciseAdminDetailsComponent } from './components/admin/exercise/exercise-admin-details/exercise-admin-details/exercise-admin-details.component';
import { ExerciseAdminEditComponent } from './components/admin/exercise/exercise-admin-edit/exercise-admin-edit/exercise-admin-edit.component';
import { AuthGuard } from './services/guards/auth.guard';
import { AuthenticationService } from './services/authentication.service';
import { RoleGuard } from './services/guards/role.guard';
import { InvitationListComponent } from './components/invitation-list/invitation-list/invitation-list.component';
import { MentorPupilsComponent } from './components/mentor-pupils/mentor-pupils/mentor-pupils.component';





const routes: Routes = [
  {
    path: 'training-plans',
    component: TrainingPlansListComponent,
    canActivate: [AuthGuard,RoleGuard('3','5')],
  },
  {
    path: 'training-plans/add',
    component: AddTrainingPlanComponent,
    canActivate: [AuthGuard,RoleGuard('3','5')],
  },
  {
    path: 'training-plans/edit/:id',
    component: EditTrainingPlanComponent,
    canActivate: [AuthGuard,RoleGuard('3','5')],
  },
  {
    path: 'training-plans/edit/:id/assignPlan',
    component: AssingPlanToPupilComponent,
    canActivate: [AuthGuard,RoleGuard('3','5')],
  },
  {
    path: 'exercises',
    component: ExercisesListComponent,
    canActivate: [AuthGuard,RoleGuard('3','5')],
   
  },
  {
    path: 'exercises/edit/:id',
    component: ExercisesEditComponent,
    canActivate: [AuthGuard,RoleGuard('3','5')],
  },
  {
    path: 'exercises/add',
    component: ExercisesAddComponent,
    canActivate: [AuthGuard,RoleGuard('3','5')],
  },
  {
    path: 'exercises/details/:id',
    component: ExercisesDetailsComponent,
    canActivate: [AuthGuard,RoleGuard('3','5')],
  },
  {
    path: 'training-plans/exercise-list/add',
    component: NewTrainingExerciseComponent,
    canActivate: [AuthGuard,RoleGuard('3','5')],
  }, 
  {
    path: 'training-plans/edit/:id/edit-training-exercise/:id',
    component: EditTrainingExerciseComponent,
    canActivate: [AuthGuard,RoleGuard('3','5')],
  }, 
  {
    path: 'training-plans/exercise-list',
    component: TrainingExerciseListComponent,
    canActivate: [AuthGuard,RoleGuard('3','5')],
  },
  {
    path: 'pupilTrainingPlans',
    component: PupilTrainingPlansListComponent,
    canActivate: [AuthGuard,RoleGuard('2')],
  },  
  {
    path: 'pupilTrainingPlans/details/:id',
    component: PupilTrainingPlanDetailsComponent,
    canActivate: [AuthGuard,RoleGuard('2')],
  },  
  {
    path: 'pupilTrainingPlans/details/:id/training-exercise-details/:id',
    component: PupilTrainingExerciseDetailsComponent,
    canActivate: [AuthGuard,RoleGuard('2')],
  },
  {
    path: 'diet',
    component: DietListComponent,
    canActivate: [AuthGuard,RoleGuard('4','5')],
  }, 
  {
    path: 'diet/add',
    component: AddDietComponent,
    canActivate: [AuthGuard,RoleGuard('4','5')],
  }, 
  {
    path: 'diet/edit/:id',
    component: EditDietComponent,
    canActivate: [AuthGuard,RoleGuard('4','5')],
  }, 
  {
    path: 'diet/edit/:id/dietMeals',
    component: DietMealsListComponent,
    canActivate: [AuthGuard,RoleGuard('4','5')],
  }, 
  {
    path: 'diet/edit/:id/dietMeals/add',
    component: NewDietMealComponent,
    canActivate: [AuthGuard,RoleGuard('4','5')],
  }, 
  {
    path: 'diet/edit/:id/dietMeals/:id',
    component: EditDietMealComponent,
    canActivate: [AuthGuard,RoleGuard('4','5')],
  }, 
  {
    path: 'diet/edit/:id/assignDiet',
    component: AssignDietComponent,
    canActivate: [AuthGuard,RoleGuard('4','5')],
  }, 
  {
    path: 'meals',
    component: MealsListComponent,
    canActivate: [AuthGuard,RoleGuard('4','5')],
  }, 
  {
    path: 'meals/add',
    component: MealsAddComponent,
    canActivate: [AuthGuard,RoleGuard('4','5')],
  }, 
  {
    path: 'meals/edit/:id',
    component: MealsEditComponent,
    canActivate: [AuthGuard,RoleGuard('4','5')],
  }, 
  {
    path: 'meals/details/:id',
    component: MealsDetailsComponent,
    canActivate: [AuthGuard,RoleGuard('4','5')],
  }, 
  {
    path: '',
    component: MainPageComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path:'register',
    component: RegisterComponent
  },
  {
    path: 'trainersList',
    component: MentorsListComponent
  },
  {
    path: 'dieticiansList',
    component: MentorsListComponent
  },
  {
    path: 'trainerProfile/:id',
    component: MentorProfileComponent
  },
  {
    path: 'dieticianProfile/:id',
    component: MentorProfileComponent
  },
  {
    path: 'pupilProfile/:id',
    component: PupilProfileComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'myProfile',
    component: MyProfileComponent,
    canActivate: [AuthGuard, RoleGuard('2','3','4','5')],
  },
  {
    path: 'myProfile/edit',
    component: MyProfileEditComponent,
    canActivate: [AuthGuard, RoleGuard('2','3','4','5')],
  },
  {
    path: 'createGym',
    component: CreateGymComponent,
    canActivate: [AuthGuard,RoleGuard('3','4','5')],
  },
  {
    path: 'admin/gym/list/:status', 
    component: GymListComponent,
    canActivate: [AuthGuard,RoleGuard('1')],
  },
  {
    path: 'admin/gym/details/:id', 
    component: GymDetailsComponent,
    canActivate: [AuthGuard,RoleGuard('1')],
  },
  {
    path: 'admin/gym/edit/:id', 
    component: GymEditComponent,
    canActivate: [AuthGuard,RoleGuard('1')],
  },
  {
    path: 'admin/gym/vetification/:id', 
    component: GymVerificationComponent,
    canActivate: [AuthGuard,RoleGuard('1')],
  },
  {
    path: 'admin/exercise/list', 
    component: ExerciseListAdminComponent,
    canActivate: [AuthGuard,RoleGuard('1')],
  },
  {
    path: 'admin/exercise/create', 
    component: ExerciseCreateAdminComponent,
    canActivate: [AuthGuard,RoleGuard('1')],
  },
  {
    path: 'addCertificate', 
    component: CreateCertificateComponent,
    canActivate: [AuthGuard,RoleGuard('3','4','5')],
  },
  {
    path: 'admin/certificatedUsers/list/:status', 
    component: CertificatedUsersListComponent,
    canActivate: [AuthGuard,RoleGuard('1')],
  },
  {
    path: 'admin/certificatedUsers/verification/:id', 
    component: UsersVerificationComponent,
    canActivate: [AuthGuard,RoleGuard('1')],
  },
  {
    path: 'admin/certificatedUsers/certificateVerification/:id', 
    component: CertificateVerificationComponent,
    canActivate: [AuthGuard,RoleGuard('1')],
  },
  {
    path: 'admin/exercise/details/:id', 
    component: ExerciseAdminDetailsComponent,
    canActivate: [AuthGuard,RoleGuard('1')],
  },
  {
    path: 'admin/exercise/edit/:id', 
    component: ExerciseAdminEditComponent,
    canActivate: [AuthGuard,RoleGuard('1')],
  },
  {
    path: 'invitationList', 
    component: InvitationListComponent,
    canActivate: [AuthGuard,RoleGuard('3','4','5')],
  },
  {
    path: 'myPupilsList', 
    component: MentorPupilsComponent,
    canActivate: [AuthGuard,RoleGuard('3','4','5')],
  },
  
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
