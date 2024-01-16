import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PupilTrainingPlansListComponent } from './pupil-training-plans-list.component';

describe('PupilTrainingPlansListComponent', () => {
  let component: PupilTrainingPlansListComponent;
  let fixture: ComponentFixture<PupilTrainingPlansListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PupilTrainingPlansListComponent]
    });
    fixture = TestBed.createComponent(PupilTrainingPlansListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
