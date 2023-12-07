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
import { TrainerListComponent } from './components/mentorsLists/trainer-list/trainer-list.component';
import { DieteticianListComponent } from './components/mentorsLists/dietetician-list/dietetician-list.component';
import { DieteticianWindowComponent } from './components/mentorsLists/dietetician-list/dietetician-window/dietetician-window.component';
import { SearchOptionsDieteticianComponent } from './components/mentorsLists/dietetician-list/search-options-dietetician/search-options-dietetician.component';
import { TrainerWindowComponent } from './components/mentorsLists/trainer-list/trainer-window/trainer-window.component';
import { SearchOptionsTrainerComponent } from './components/mentorsLists/trainer-list/search-options-trainer/search-options-trainer.component';
import { DropdownSelectTrainerComponent } from './components/mentorsLists/trainer-list/search-options-trainer/dropdown-select-trainer/dropdown-select-trainer.component';
import { TrainerService } from './services/trainer.service';
import { TrainerProfileComponent } from './components/mentorsLists/trainer-profile/trainer-profile.component';
import { TrainerOpinionComponent } from './components/mentorsLists/trainer-profile/trainer-opinion/trainer-opinion.component';
import { LoginComponent } from './components/authentication/login/login.component';
import { RegisterComponent } from './components/authentication/register/register.component';
import { PasswordRecoveryComponent } from './components/authentication/password-recovery/password-recovery.component';
import { MenuComponent } from './components/main/menu/menu.component';
import { SearchComponent } from './components/main/search/search.component';
import { FooterComponent } from './components/main/footer/footer.component';
import { MenuButtonComponent } from './components/main/menu/menu-button/menu-button.component';
import { SelectDeteticianComponent } from './components/mentorsLists/dietetician-list/search-options-dietetician/select-detetician/select-detetician.component';


  

@NgModule({
  declarations: [
    AppComponent,
    ExercisesListComponent,
    TrainingPlansListComponent,
    AddTrainingPlanComponent,
    EditTrainingPlanComponent,
    NewTrainingExerciseComponent,
    TrainerListComponent,
    DieteticianListComponent,
    DieteticianWindowComponent,
    SearchOptionsDieteticianComponent,
    TrainerWindowComponent,
    SearchOptionsTrainerComponent,
    DropdownSelectTrainerComponent,
    TrainerProfileComponent,
    TrainerOpinionComponent,
    LoginComponent,
    RegisterComponent,
    PasswordRecoveryComponent,
    MenuComponent,
    SearchComponent,
    FooterComponent,
    MenuButtonComponent,
    SelectDeteticianComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
  ],
  providers: [TrainerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
