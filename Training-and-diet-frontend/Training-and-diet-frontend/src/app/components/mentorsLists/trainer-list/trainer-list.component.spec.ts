import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainerListComponent } from './trainer-list.component';

describe('TrainerListComponent', () => {
  let component: TrainerListComponent;
  let fixture: ComponentFixture<TrainerListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TrainerListComponent]
    });
    fixture = TestBed.createComponent(TrainerListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
