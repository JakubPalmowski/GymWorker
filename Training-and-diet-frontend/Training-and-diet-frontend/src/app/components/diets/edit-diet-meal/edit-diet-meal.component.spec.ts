import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditDietMealComponent } from './edit-diet-meal.component';

describe('EditDietMealComponent', () => {
  let component: EditDietMealComponent;
  let fixture: ComponentFixture<EditDietMealComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EditDietMealComponent]
    });
    fixture = TestBed.createComponent(EditDietMealComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
