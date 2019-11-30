import { TestBed } from '@angular/core/testing';

import { AttandenceService } from './attandence.service';

describe('AttandenceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AttandenceService = TestBed.get(AttandenceService);
    expect(service).toBeTruthy();
  });
});
