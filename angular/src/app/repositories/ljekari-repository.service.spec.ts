/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { LjekariRepositoryService } from './ljekari-repository.service';

describe('Service: LjekariRepository', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LjekariRepositoryService]
    });
  });

  it('should ...', inject([LjekariRepositoryService], (service: LjekariRepositoryService) => {
    expect(service).toBeTruthy();
  }));
});
