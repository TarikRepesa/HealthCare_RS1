import { TestBed } from '@angular/core/testing';

import { SifraBolestiRepositoryService } from './sifra-bolesti-repository.service';

describe('SifraBolestiRepositoryService', () => {
  let service: SifraBolestiRepositoryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SifraBolestiRepositoryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
