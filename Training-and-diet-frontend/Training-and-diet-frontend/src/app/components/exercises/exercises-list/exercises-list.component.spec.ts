import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExercisesListComponent } from './exercises-list.component';

describe('ExercisesListComponent', () => {
  let component: ExercisesListComponent;
  let fixture: ComponentFixture<ExercisesListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ExercisesListComponent]
    });
    fixture = TestBed.createComponent(ExercisesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
