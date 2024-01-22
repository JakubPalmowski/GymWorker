import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditDietComponent } from './edit-diet.component';

describe('EditDietComponent', () => {
  let component: EditDietComponent;
  let fixture: ComponentFixture<EditDietComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EditDietComponent]
    });
    fixture = TestBed.createComponent(EditDietComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
