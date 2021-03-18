import { TestBed } from '@angular/core/testing';

import { OvidGraphService } from './ovid-graph.service';

describe('OvidGraphService', () => {
  let service: OvidGraphService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OvidGraphService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
