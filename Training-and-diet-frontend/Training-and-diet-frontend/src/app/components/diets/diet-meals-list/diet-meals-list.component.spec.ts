import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DietMealsListComponent } from './diet-meals-list.component';

describe('DietMealsListComponent', () => {
  let component: DietMealsListComponent;
  let fixture: ComponentFixture<DietMealsListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DietMealsListComponent]
    });
    fixture = TestBed.createComponent(DietMealsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
