import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DropdownSelectTrainerComponent } from './dropdown-select-trainer.component';

describe('DropdownSelectTrainerComponent', () => {
  let component: DropdownSelectTrainerComponent;
  let fixture: ComponentFixture<DropdownSelectTrainerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DropdownSelectTrainerComponent]
    });
    fixture = TestBed.createComponent(DropdownSelectTrainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
