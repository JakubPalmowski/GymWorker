import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewTrainingExerciseComponent } from './new-training-exercise.component';

describe('NewTrainingExerciseComponent', () => {
  let component: NewTrainingExerciseComponent;
  let fixture: ComponentFixture<NewTrainingExerciseComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NewTrainingExerciseComponent]
    });
    fixture = TestBed.createComponent(NewTrainingExerciseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
