import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssignDietComponent } from './assign-diet.component';

describe('AssignDietComponent', () => {
  let component: AssignDietComponent;
  let fixture: ComponentFixture<AssignDietComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AssignDietComponent]
    });
    fixture = TestBed.createComponent(AssignDietComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
