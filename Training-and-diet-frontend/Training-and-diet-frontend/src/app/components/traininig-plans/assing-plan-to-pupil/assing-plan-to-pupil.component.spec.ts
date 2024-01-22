import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssingPlanToPupilComponent } from './assing-plan-to-pupil.component';

describe('AssingPlanToPupilComponent', () => {
  let component: AssingPlanToPupilComponent;
  let fixture: ComponentFixture<AssingPlanToPupilComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AssingPlanToPupilComponent]
    });
    fixture = TestBed.createComponent(AssingPlanToPupilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
