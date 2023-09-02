import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainingPlansListComponent } from './training-plans-list.component';

describe('TrainingPlansListComponent', () => {
  let component: TrainingPlansListComponent;
  let fixture: ComponentFixture<TrainingPlansListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TrainingPlansListComponent]
    });
    fixture = TestBed.createComponent(TrainingPlansListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
