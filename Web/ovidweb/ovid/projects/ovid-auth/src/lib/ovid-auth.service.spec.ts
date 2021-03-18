import { TestBed } from '@angular/core/testing';

import { OvidAuthService } from './ovid-auth.service';

describe('OvidAuthService', () => {
  let service: OvidAuthService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OvidAuthService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
