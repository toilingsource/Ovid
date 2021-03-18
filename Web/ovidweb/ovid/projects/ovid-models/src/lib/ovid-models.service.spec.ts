import { TestBed } from '@angular/core/testing';

import { OvidModelsService } from './ovid-models.service';

describe('OvidModelsService', () => {
  let service: OvidModelsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OvidModelsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
