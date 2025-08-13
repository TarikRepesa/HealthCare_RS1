import { TestBed } from '@angular/core/testing';

import { LijekoviRepositoryService } from './lijekovi-repository.service';

describe('LijekoviRepositoryService', () => {
  let service: LijekoviRepositoryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LijekoviRepositoryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
