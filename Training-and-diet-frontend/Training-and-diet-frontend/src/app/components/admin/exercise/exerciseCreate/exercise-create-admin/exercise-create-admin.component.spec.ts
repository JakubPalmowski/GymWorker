import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExerciseCreateAdminComponent } from './exercise-create-admin.component';

describe('ExerciseCreateAdminComponent', () => {
  let component: ExerciseCreateAdminComponent;
  let fixture: ComponentFixture<ExerciseCreateAdminComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ExerciseCreateAdminComponent]
    });
    fixture = TestBed.createComponent(ExerciseCreateAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
