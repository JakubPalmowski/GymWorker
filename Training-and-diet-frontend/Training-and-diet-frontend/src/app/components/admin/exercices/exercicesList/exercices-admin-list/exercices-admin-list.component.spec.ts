import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExercicesAdminListComponent } from './exercices-admin-list.component';

describe('ExercicesAdminListComponent', () => {
  let component: ExercicesAdminListComponent;
  let fixture: ComponentFixture<ExercicesAdminListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ExercicesAdminListComponent]
    });
    fixture = TestBed.createComponent(ExercicesAdminListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
