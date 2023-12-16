import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ExercisesListComponent } from './components/exercises/exercises-list/exercises-list.component';
import { TrainingPlansListComponent } from './components/traininig-plans/training-plans-list/training-plans-list.component';
import { HttpClientModule } from '@angular/common/http';
import { AddTrainingPlanComponent } from './components/traininig-plans/add-training-plan/add-training-plan.component';
import { FormsModule } from '@angular/forms';
import { EditTrainingPlanComponent } from './components/traininig-plans/edit-training-plan/edit-training-plan.component';
import { NewTrainingExerciseComponent } from './components/exercises/new-training-exercise/new-training-exercise.component';
import { UserService } from './services/user.service';
import { LoginComponent } from './components/authentication/login/login.component';
import { RegisterComponent } from './components/authentication/register/register.component';
import { PasswordRecoveryComponent } from './components/authentication/password-recovery/password-recovery.component';
import { MenuComponent } from './components/main/menu/menu.component';
import { SearchComponent } from './components/main/search/search.component';
import { FooterComponent } from './components/main/footer/footer.component';
import { MenuButtonComponent } from './components/main/menu/menu-button/menu-button.component';
import { SelectDeteticianComponent } from './components/mentorsLists/dietetician-list/search-options-dietetician/select-detetician/select-detetician.component';
import { MentorsListComponent } from './components/mentors-list/mentors-list.component';
import { MentorProfileComponent } from './components/mentor-profile/mentor-profile.component';
import { MentorWindowComponent } from './components/mentors-list/mentor-window/mentor-window.component';
import { SearchOptionsComponent } from './components/mentors-list/search-options/search-options.component';
import { SelectComponent } from './components/mentors-list/search-options/select/select.component';
import { TrainerOpinionComponent } from './components/mentor-profile/trainer-opinion/trainer-opinion.component';


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
    MenuButtonComponent,
    SelectDeteticianComponent,
    MentorsListComponent,
    MentorProfileComponent,
    MentorWindowComponent,
    SearchOptionsComponent,
    SelectComponent,
    TrainerOpinionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
