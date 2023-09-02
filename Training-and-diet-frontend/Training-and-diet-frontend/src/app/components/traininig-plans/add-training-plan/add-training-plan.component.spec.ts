import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddTrainingPlanComponent } from './add-training-plan.component';

describe('AddTrainingPlanComponent', () => {
  let component: AddTrainingPlanComponent;
  let fixture: ComponentFixture<AddTrainingPlanComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddTrainingPlanComponent]
    });
    fixture = TestBed.createComponent(AddTrainingPlanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
