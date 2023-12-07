import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DieteticianListComponent } from './dietetician-list.component';

describe('DieteticianListComponent', () => {
  let component: DieteticianListComponent;
  let fixture: ComponentFixture<DieteticianListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DieteticianListComponent]
    });
    fixture = TestBed.createComponent(DieteticianListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
