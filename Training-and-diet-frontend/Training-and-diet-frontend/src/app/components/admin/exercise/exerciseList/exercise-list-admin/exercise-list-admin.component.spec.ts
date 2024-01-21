import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExerciseListAdminComponent } from './exercise-list-admin.component';

describe('ExerciseListAdminComponent', () => {
  let component: ExerciseListAdminComponent;
  let fixture: ComponentFixture<ExerciseListAdminComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ExerciseListAdminComponent]
    });
    fixture = TestBed.createComponent(ExerciseListAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
