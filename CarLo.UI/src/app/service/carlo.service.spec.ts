import { TestBed } from '@angular/core/testing';

import { CarloService } from './carlo.service';

describe('CarloService', () => {
  let service: CarloService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CarloService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
