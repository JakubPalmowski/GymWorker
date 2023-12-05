import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectDeteticianComponent } from './select-detetician.component';

describe('SelectDeteticianComponent', () => {
  let component: SelectDeteticianComponent;
  let fixture: ComponentFixture<SelectDeteticianComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SelectDeteticianComponent]
    });
    fixture = TestBed.createComponent(SelectDeteticianComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
