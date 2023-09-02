import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ExercisesListComponent } from './components/exercises/exercises-list/exercises-list.component';
import { TrainingPlansListComponent } from './components/traininig-plans/training-plans-list/training-plans-list.component';
import { HttpClientModule } from '@angular/common/http';
import { AddTrainingPlanComponent } from './components/traininig-plans/add-training-plan/add-training-plan.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    ExercisesListComponent,
    TrainingPlansListComponent,
    AddTrainingPlanComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
