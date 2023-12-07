import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DieteticianWindowComponent } from './dietetician-window.component';

describe('DieteticianWindowComponent', () => {
  let component: DieteticianWindowComponent;
  let fixture: ComponentFixture<DieteticianWindowComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DieteticianWindowComponent]
    });
    fixture = TestBed.createComponent(DieteticianWindowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
