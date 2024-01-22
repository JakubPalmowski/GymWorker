import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateCertificateComponent } from './create-certificate.component';

describe('CreateCertificateComponent', () => {
  let component: CreateCertificateComponent;
  let fixture: ComponentFixture<CreateCertificateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CreateCertificateComponent]
    });
    fixture = TestBed.createComponent(CreateCertificateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
