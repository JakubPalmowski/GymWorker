import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MealsEditComponent } from './meals-edit.component';

describe('MealsEditComponent', () => {
  let component: MealsEditComponent;
  let fixture: ComponentFixture<MealsEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MealsEditComponent]
    });
    fixture = TestBed.createComponent(MealsEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
