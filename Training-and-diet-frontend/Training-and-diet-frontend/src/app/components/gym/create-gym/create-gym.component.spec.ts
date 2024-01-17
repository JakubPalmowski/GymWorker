import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateGymComponent } from './create-gym.component';

describe('CreateGymComponent', () => {
  let component: CreateGymComponent;
  let fixture: ComponentFixture<CreateGymComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CreateGymComponent]
    });
    fixture = TestBed.createComponent(CreateGymComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
