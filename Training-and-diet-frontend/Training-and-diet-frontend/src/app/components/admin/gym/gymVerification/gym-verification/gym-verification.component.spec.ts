import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GymVerificationComponent } from './gym-verification.component';

describe('GymVerificationComponent', () => {
  let component: GymVerificationComponent;
  let fixture: ComponentFixture<GymVerificationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GymVerificationComponent]
    });
    fixture = TestBed.createComponent(GymVerificationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
