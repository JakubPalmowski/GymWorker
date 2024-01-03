import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MealsDetailsComponent } from './meals-details.component';

describe('MealsDetailsComponent', () => {
  let component: MealsDetailsComponent;
  let fixture: ComponentFixture<MealsDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MealsDetailsComponent]
    });
    fixture = TestBed.createComponent(MealsDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
