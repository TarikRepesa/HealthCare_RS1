/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { UputniceRepositoryService } from './uputnice-repository.service';

describe('Service: NalaziRepository', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [UputniceRepositoryService]
    });
  });

  it('should ...', inject([UputniceRepositoryService], (service: UputniceRepositoryService) => {
    expect(service).toBeTruthy();
  }));
});
