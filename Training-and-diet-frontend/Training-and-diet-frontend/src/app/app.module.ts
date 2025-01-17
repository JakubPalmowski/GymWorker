import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ExercisesListComponent } from './components/exercises/exercises-list/exercises-list.component';
import { TrainingPlansListComponent } from './components/traininig-plans/training-plans-list/training-plans-list.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AddTrainingPlanComponent } from './components/traininig-plans/add-training-plan/add-training-plan.component';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { EditTrainingPlanComponent } from './components/traininig-plans/edit-training-plan/edit-training-plan.component';
import { NewTrainingExerciseComponent } from './components/traininig-plans/new-training-exercise/new-training-exercise.component';
import { LoginComponent } from './components/authentication/login/login.component';
import { RegisterComponent } from './components/authentication/register/register.component';
import { MenuComponent } from './components/main/menu/menu.component';
import { SearchComponent } from './components/main/search/search.component';
import { FooterComponent } from './components/main/footer/footer.component';
import { MentorsListComponent } from './components/mentors-list/mentors-list.component';
import { MentorProfileComponent } from './components/mentor-profile/mentor-profile.component';
import { MentorWindowComponent } from './components/mentors-list/mentor-window/mentor-window.component';
import { SearchOptionsComponent } from './components/mentors-list/search-options/search-options.component';
import { MentorOpinionComponent } from './components/mentor-profile/mentor-opinion/mentor-opinion.component';
import { ExercisesEditComponent } from './components/exercises/exercises-edit/exercises-edit.component';
import { ExercisesAddComponent } from './components/exercises/exercises-add/exercises-add.component';
import { AutocompleteDirective } from './directives/autocompleteDirective';
import { PupilProfileComponent } from './components/pupil-profile/pupil-profile.component';
import { ExercisesDetailsComponent } from './components/exercises/exercises-details/exercises-details.component';
import { MealsDetailsComponent } from './components/meals/meals-details/meals-details.component';
import { MealsAddComponent } from './components/meals/meals-add/meals-add.component';
import { MealsEditComponent } from './components/meals/meals-edit/meals-edit.component';
import { MealsListComponent } from './components/meals/meals-list/meals-list.component';
import { MyProfileComponent } from './components/my-profile/my-profile/my-profile.component';
import { MyProfileEditComponent } from './components/my-profile/my-profile-edit/my-profile-edit.component';
import { EditTrainingExerciseComponent } from './components/traininig-plans/edit-training-exercise/edit-training-exercise.component';
import { TrainingExerciseListComponent } from './components/traininig-plans/training-exercise-list/training-exercise-list.component';
import { PupilTrainingPlansListComponent } from './components/pupil-training-plan/pupil-training-plans-list/pupil-training-plans-list.component';
import { PupilTrainingPlanDetailsComponent } from './components/pupil-training-plan/pupil-training-plan-details/pupil-training-plan-details.component';
import { PupilTrainingExerciseDetailsComponent } from './components/pupil-training-plan/pupil-training-exercise-details/pupil-training-exercise-details.component';
import { CreateGymComponent } from './components/gym/create-gym/create-gym.component';
import { AuthenticationInterceptor } from './services/interceptors/authentication-interceptor';
import { MainPageComponent } from './components/main-page/main-page/main-page.component';
import { GymListComponent } from './components/admin/gym/gym-list/gym-list/gym-list.component';
import { GymDetailsComponent } from './components/admin/gym/gym-details/gym-details/gym-details.component';
import { GymEditComponent } from './components/admin/gym/gym-edit/gym-edit/gym-edit.component';
import { GymVerificationComponent } from './components/admin/gym/gym-verification/gym-verification/gym-verification.component';
import { MenuAdminComponent } from './components/admin/menu-admin/menu-admin/menu-admin.component';
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
import { NewDietMealComponent } from './components/diets/new-diet-meal/new-diet-meal.component';
import { DietMealsListComponent } from './components/diets/diet-meals-list/diet-meals-list.component';
import { AssignDietComponent } from './components/diets/assign-diet/assign-diet.component';
import { EditDietMealComponent } from './components/diets/edit-diet-meal/edit-diet-meal.component';
import { ExerciseAdminDetailsComponent } from './components/admin/exercise/exercise-admin-details/exercise-admin-details/exercise-admin-details.component';
import { ExerciseAdminEditComponent } from './components/admin/exercise/exercise-admin-edit/exercise-admin-edit/exercise-admin-edit.component';
import { InvitationListComponent } from './components/invitation-list/invitation-list/invitation-list.component';
import { MentorPupilsComponent } from './components/mentor-pupils/mentor-pupils/mentor-pupils.component';
import { PupilDietListComponent } from './components/pupil-diet/pupil-diet-list/pupil-diet-list.component';
import { PupilDietDetailsComponent } from './components/pupil-diet/pupil-diet-details/pupil-diet-details.component';
import { PupilDietMealDetailsComponent } from './components/pupil-diet/pupil-diet-meal-details/pupil-diet-meal-details.component';






@NgModule({
  declarations: [
    AppComponent,
    ExercisesListComponent,
    TrainingPlansListComponent,
    AddTrainingPlanComponent,
    EditTrainingPlanComponent,
    NewTrainingExerciseComponent,
    LoginComponent,
    RegisterComponent,
    MenuComponent,
    SearchComponent,
    FooterComponent,
    MentorsListComponent,
    MentorProfileComponent,
    MentorWindowComponent,
    SearchOptionsComponent,
    MentorOpinionComponent,
    ExercisesEditComponent,
    ExercisesAddComponent, 
    AutocompleteDirective,
    PupilProfileComponent, 
    ExercisesDetailsComponent, 
    MealsDetailsComponent, 
    MealsAddComponent, 
    MealsEditComponent, 
    MealsListComponent,
    TrainingExerciseListComponent,
    EditTrainingExerciseComponent,
    MyProfileComponent, 
    MyProfileEditComponent,
    PupilTrainingPlansListComponent,
    PupilTrainingPlanDetailsComponent,
    PupilTrainingExerciseDetailsComponent,
    CreateGymComponent,
    MainPageComponent,
    GymListComponent,
    GymDetailsComponent,
    GymEditComponent,
    GymVerificationComponent,
    MenuAdminComponent,
    ExerciseListAdminComponent,
    ExerciseCreateAdminComponent,
    CreateCertificateComponent,
    CertificatedUsersListComponent,
    UsersVerificationComponent,
    CertificateVerificationComponent,
    AssingPlanToPupilComponent,
    DietListComponent,
    AddDietComponent,
    EditDietComponent,
    NewDietMealComponent,
    DietMealsListComponent,
    AssignDietComponent,
    EditDietMealComponent,
    ExerciseAdminDetailsComponent,
    ExerciseAdminEditComponent,
    InvitationListComponent,
    MentorPupilsComponent,
    PupilDietListComponent,
    PupilDietDetailsComponent,
    PupilDietMealDetailsComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthenticationInterceptor,
      multi:true
    }
  ],
  bootstrap: [AppComponent]

})
export class AppModule { }
