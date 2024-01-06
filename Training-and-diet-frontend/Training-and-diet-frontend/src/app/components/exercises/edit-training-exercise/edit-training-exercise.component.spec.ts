import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditTrainingExerciseComponent } from './edit-training-exercise.component';

describe('EditTrainingExerciseComponent', () => {
  let component: EditTrainingExerciseComponent;
  let fixture: ComponentFixture<EditTrainingExerciseComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EditTrainingExerciseComponent]
    });
    fixture = TestBed.createComponent(EditTrainingExerciseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
