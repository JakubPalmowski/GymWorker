import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DietListComponent } from './diet-list.component';

describe('DietListComponent', () => {
  let component: DietListComponent;
  let fixture: ComponentFixture<DietListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DietListComponent]
    });
    fixture = TestBed.createComponent(DietListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
