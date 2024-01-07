import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ExercisesListComponent } from './components/exercises/exercises-list/exercises-list.component';
import { TrainingPlansListComponent } from './components/traininig-plans/training-plans-list/training-plans-list.component';
import { HttpClientModule } from '@angular/common/http';
import { AddTrainingPlanComponent } from './components/traininig-plans/add-training-plan/add-training-plan.component';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { EditTrainingPlanComponent } from './components/traininig-plans/edit-training-plan/edit-training-plan.component';
import { NewTrainingExerciseComponent } from './components/traininig-plans/new-training-exercise/new-training-exercise.component';
import { LoginComponent } from './components/authentication/login/login.component';
import { RegisterComponent } from './components/authentication/register/register.component';
import { PasswordRecoveryComponent } from './components/authentication/password-recovery/password-recovery.component';
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
import { MyProfileComponent } from './components/myProfile/my-profile/my-profile.component';
import { MyProfileEditComponent } from './components/myProfile/my-profile-edit/my-profile-edit.component';
import { EditTrainingExerciseComponent } from './components/traininig-plans/edit-training-exercise/edit-training-exercise.component';
import { TrainingExerciseListComponent } from './components/traininig-plans/training-exercise-list/training-exercise-list.component';




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
    PasswordRecoveryComponent,
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
    EditTrainingExerciseComponent
    AutocompleteDirective, PupilProfileComponent, ExercisesDetailsComponent, MealsDetailsComponent, MealsAddComponent, MealsEditComponent, MealsListComponent, MyProfileComponent, MyProfileEditComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
