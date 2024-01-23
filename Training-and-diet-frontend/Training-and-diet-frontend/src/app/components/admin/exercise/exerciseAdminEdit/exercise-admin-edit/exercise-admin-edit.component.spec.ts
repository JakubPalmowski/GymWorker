import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExerciseAdminEditComponent } from './exercise-admin-edit.component';

describe('ExerciseAdminEditComponent', () => {
  let component: ExerciseAdminEditComponent;
  let fixture: ComponentFixture<ExerciseAdminEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ExerciseAdminEditComponent]
    });
    fixture = TestBed.createComponent(ExerciseAdminEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
