import { TestBed } from '@angular/core/testing';

import { CertificateService } from './certificate.service';

describe('CertificateService', () => {
  let service: CertificateService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CertificateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
