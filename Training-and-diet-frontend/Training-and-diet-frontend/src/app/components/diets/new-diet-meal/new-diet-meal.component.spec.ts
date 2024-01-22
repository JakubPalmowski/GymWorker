import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewDietMealComponent } from './new-diet-meal.component';

describe('NewDietMealComponent', () => {
  let component: NewDietMealComponent;
  let fixture: ComponentFixture<NewDietMealComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NewDietMealComponent]
    });
    fixture = TestBed.createComponent(NewDietMealComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
