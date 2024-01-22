import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CertificatedUsersListComponent } from './certificated-users-list.component';

describe('CertificatedUsersListComponent', () => {
  let component: CertificatedUsersListComponent;
  let fixture: ComponentFixture<CertificatedUsersListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CertificatedUsersListComponent]
    });
    fixture = TestBed.createComponent(CertificatedUsersListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
