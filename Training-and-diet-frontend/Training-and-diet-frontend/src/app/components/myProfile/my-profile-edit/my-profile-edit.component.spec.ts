import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyProfileEditComponent } from './my-profile-edit.component';

describe('MyProfileEditComponent', () => {
  let component: MyProfileEditComponent;
  let fixture: ComponentFixture<MyProfileEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MyProfileEditComponent]
    });
    fixture = TestBed.createComponent(MyProfileEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
