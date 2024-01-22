import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsersVerificationComponent } from './users-verification.component';

describe('UsersVerificationComponent', () => {
  let component: UsersVerificationComponent;
  let fixture: ComponentFixture<UsersVerificationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UsersVerificationComponent]
    });
    fixture = TestBed.createComponent(UsersVerificationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
