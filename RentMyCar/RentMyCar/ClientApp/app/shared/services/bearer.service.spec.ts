import { TestBed, inject } from '@angular/core/testing';

import { BearerService } from './bearer.service';

describe('BearerService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BearerService]
    });
  });

  it('should be created', inject([BearerService], (service: BearerService) => {
    expect(service).toBeTruthy();
  }));
});
