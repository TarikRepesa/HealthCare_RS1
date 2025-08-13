/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { FarmaceutiRepositoryService } from './farmaceuti-repository.service';

describe('Service: FarmaceutiRepository', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FarmaceutiRepositoryService]
    });
  });

  it('should ...', inject([FarmaceutiRepositoryService], (service: FarmaceutiRepositoryService) => {
    expect(service).toBeTruthy();
  }));
});
