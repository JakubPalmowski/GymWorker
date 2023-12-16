import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExercisesAddComponent } from './exercises-add.component';

describe('ExercisesAddComponent', () => {
  let component: ExercisesAddComponent;
  let fixture: ComponentFixture<ExercisesAddComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ExercisesAddComponent]
    });
    fixture = TestBed.createComponent(ExercisesAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
