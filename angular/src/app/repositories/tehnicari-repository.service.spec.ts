/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { TehnicariRepositoryService } from './tehnicari-repository.service';

describe('Service: TehnicariRepository', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TehnicariRepositoryService]
    });
  });

  it('should ...', inject([TehnicariRepositoryService], (service: TehnicariRepositoryService) => {
    expect(service).toBeTruthy();
  }));
});
