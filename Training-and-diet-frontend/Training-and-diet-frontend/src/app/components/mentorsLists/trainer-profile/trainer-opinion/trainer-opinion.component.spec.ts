import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainerOpinionComponent } from './trainer-opinion.component';

describe('TrainerOpinionComponent', () => {
  let component: TrainerOpinionComponent;
  let fixture: ComponentFixture<TrainerOpinionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TrainerOpinionComponent]
    });
    fixture = TestBed.createComponent(TrainerOpinionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
