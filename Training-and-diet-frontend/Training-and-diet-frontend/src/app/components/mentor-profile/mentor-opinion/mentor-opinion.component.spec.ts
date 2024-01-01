import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MentorOpinionComponent } from './mentor-opinion.component';

describe('MentorOpinionComponent', () => {
  let component: MentorOpinionComponent;
  let fixture: ComponentFixture<MentorOpinionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MentorOpinionComponent]
    });
    fixture = TestBed.createComponent(MentorOpinionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
