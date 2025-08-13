import { TestBed } from '@angular/core/testing';

import { OdsjekRepositoryService } from './odsjek-repository.service';

describe('OdsjekRepositoryService', () => {
  let service: OdsjekRepositoryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OdsjekRepositoryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
