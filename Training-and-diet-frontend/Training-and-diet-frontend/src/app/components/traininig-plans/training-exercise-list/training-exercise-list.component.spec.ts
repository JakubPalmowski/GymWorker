import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainingExerciseListComponent } from './training-exercise-list.component';

describe('TrainingExerciseListComponent', () => {
  let component: TrainingExerciseListComponent;
  let fixture: ComponentFixture<TrainingExerciseListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TrainingExerciseListComponent]
    });
    fixture = TestBed.createComponent(TrainingExerciseListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
