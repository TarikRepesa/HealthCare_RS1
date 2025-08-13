import { TestBed } from '@angular/core/testing';
import { ZahtjeviLijekovaRepositoryService } from './zahtjevi-lijekova-repository.service';

describe('LijekoviRepositoryService', () => {
  let service: ZahtjeviLijekovaRepositoryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ZahtjeviLijekovaRepositoryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
