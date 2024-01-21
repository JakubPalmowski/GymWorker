import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GymEditComponent } from './gym-edit.component';

describe('GymEditComponent', () => {
  let component: GymEditComponent;
  let fixture: ComponentFixture<GymEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GymEditComponent]
    });
    fixture = TestBed.createComponent(GymEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
