import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PupilDietMealDetailsComponent } from './pupil-diet-meal-details.component';

describe('PupilDietMealDetailsComponent', () => {
  let component: PupilDietMealDetailsComponent;
  let fixture: ComponentFixture<PupilDietMealDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PupilDietMealDetailsComponent]
    });
    fixture = TestBed.createComponent(PupilDietMealDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
