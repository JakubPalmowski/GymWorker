import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExercisesDetailsComponent } from './exercises-details.component';

describe('ExercisesDetailsComponent', () => {
  let component: ExercisesDetailsComponent;
  let fixture: ComponentFixture<ExercisesDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ExercisesDetailsComponent]
    });
    fixture = TestBed.createComponent(ExercisesDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
