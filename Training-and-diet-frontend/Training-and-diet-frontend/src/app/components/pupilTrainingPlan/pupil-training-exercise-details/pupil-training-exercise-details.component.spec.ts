import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PupilTrainingExerciseDetailsComponent } from './pupil-training-exercise-details.component';

describe('PupilTrainingExerciseDetailsComponent', () => {
  let component: PupilTrainingExerciseDetailsComponent;
  let fixture: ComponentFixture<PupilTrainingExerciseDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PupilTrainingExerciseDetailsComponent]
    });
    fixture = TestBed.createComponent(PupilTrainingExerciseDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
