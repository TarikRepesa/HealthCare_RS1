/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ReceptiRepositoryService } from './recepti-repository.service';

describe('Service: ReceptiRepository', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ReceptiRepositoryService]
    });
  });

  it('should ...', inject([ReceptiRepositoryService], (service: ReceptiRepositoryService) => {
    expect(service).toBeTruthy();
  }));
});
