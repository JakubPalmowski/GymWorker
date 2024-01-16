import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PupilTrainingPlanDetailsComponent } from './pupil-training-plan-details.component';

describe('PupilTrainingPlanDetailsComponent', () => {
  let component: PupilTrainingPlanDetailsComponent;
  let fixture: ComponentFixture<PupilTrainingPlanDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PupilTrainingPlanDetailsComponent]
    });
    fixture = TestBed.createComponent(PupilTrainingPlanDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
