import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PupilProfileComponent } from './pupil-profile.component';

describe('PupilProfileComponent', () => {
  let component: PupilProfileComponent;
  let fixture: ComponentFixture<PupilProfileComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PupilProfileComponent]
    });
    fixture = TestBed.createComponent(PupilProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
