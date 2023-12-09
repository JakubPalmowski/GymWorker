import { TestBed } from '@angular/core/testing';

import { TrainerProfileService } from './trainer-profile.service';

describe('TrainerProfileService', () => {
  let service: TrainerProfileService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TrainerProfileService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
