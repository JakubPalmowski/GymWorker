import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MentorPupilsComponent } from './mentor-pupils.component';

describe('MentorPupilsComponent', () => {
  let component: MentorPupilsComponent;
  let fixture: ComponentFixture<MentorPupilsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MentorPupilsComponent]
    });
    fixture = TestBed.createComponent(MentorPupilsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
