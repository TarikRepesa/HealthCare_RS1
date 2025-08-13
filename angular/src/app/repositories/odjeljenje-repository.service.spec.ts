import { TestBed } from '@angular/core/testing';

import { OdjeljenjeRepositoryService } from './odjeljenje-repository.service';

describe('OdjeljenjeRepositoryService', () => {
  let service: OdjeljenjeRepositoryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OdjeljenjeRepositoryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
