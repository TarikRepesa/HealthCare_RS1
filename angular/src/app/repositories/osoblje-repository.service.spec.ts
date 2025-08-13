import { TestBed } from '@angular/core/testing';

import { OsobljeRepositoryService } from './osoblje-repository.service';

describe('OsobljeRepositoryService', () => {
  let service: OsobljeRepositoryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OsobljeRepositoryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
