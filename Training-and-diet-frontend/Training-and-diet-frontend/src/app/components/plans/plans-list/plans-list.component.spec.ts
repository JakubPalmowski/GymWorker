import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlansListComponent } from './plans-list.component';

describe('PlansListComponent', () => {
  let component: PlansListComponent;
  let fixture: ComponentFixture<PlansListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PlansListComponent]
    });
    fixture = TestBed.createComponent(PlansListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
