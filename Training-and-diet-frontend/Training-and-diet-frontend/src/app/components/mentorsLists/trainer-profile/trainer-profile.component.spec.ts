import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainerProfileComponent } from './trainer-profile.component';

describe('TrainerProfileComponent', () => {
  let component: TrainerProfileComponent;
  let fixture: ComponentFixture<TrainerProfileComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TrainerProfileComponent]
    });
    fixture = TestBed.createComponent(TrainerProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
