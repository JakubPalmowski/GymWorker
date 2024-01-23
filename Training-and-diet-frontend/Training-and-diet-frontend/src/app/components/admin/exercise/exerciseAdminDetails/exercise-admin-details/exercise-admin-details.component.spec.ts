import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExerciseAdminDetailsComponent } from './exercise-admin-details.component';

describe('ExerciseAdminDetailsComponent', () => {
  let component: ExerciseAdminDetailsComponent;
  let fixture: ComponentFixture<ExerciseAdminDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ExerciseAdminDetailsComponent]
    });
    fixture = TestBed.createComponent(ExerciseAdminDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
