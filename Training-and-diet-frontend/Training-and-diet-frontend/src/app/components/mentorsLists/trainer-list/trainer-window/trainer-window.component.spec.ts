import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainerWindowComponent } from './trainer-window.component';

describe('TrainerWindowComponent', () => {
  let component: TrainerWindowComponent;
  let fixture: ComponentFixture<TrainerWindowComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TrainerWindowComponent]
    });
    fixture = TestBed.createComponent(TrainerWindowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
