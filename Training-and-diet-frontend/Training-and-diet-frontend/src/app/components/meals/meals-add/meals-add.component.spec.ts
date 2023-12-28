import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MealsAddComponent } from './meals-add.component';

describe('MealsAddComponent', () => {
  let component: MealsAddComponent;
  let fixture: ComponentFixture<MealsAddComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MealsAddComponent]
    });
    fixture = TestBed.createComponent(MealsAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
