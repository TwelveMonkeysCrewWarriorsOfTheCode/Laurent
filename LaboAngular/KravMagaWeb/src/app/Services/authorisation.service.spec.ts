import { HttpHeaders } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { AuthorisationService } from './authorisation.service';

const httpOptions = {
  headers: new HttpHeaders( {'Content-Type': 'application/json'})
}

describe('AuthorisationService', () => {
  let service: AuthorisationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AuthorisationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
