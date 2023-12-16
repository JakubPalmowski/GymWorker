import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MentorsListComponent } from './mentors-list.component';

describe('MentorsListComponent', () => {
  let component: MentorsListComponent;
  let fixture: ComponentFixture<MentorsListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MentorsListComponent]
    });
    fixture = TestBed.createComponent(MentorsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
