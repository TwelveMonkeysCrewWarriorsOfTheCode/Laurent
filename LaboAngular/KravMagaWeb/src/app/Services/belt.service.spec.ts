import { TestBed } from '@angular/core/testing';

import { BeltService } from './belt.service';

describe('BeltService', () => {
  let service: BeltService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BeltService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
