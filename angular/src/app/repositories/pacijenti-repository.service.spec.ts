/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PacijentiRepositoryService } from './pacijenti-repository.service';

describe('Service: PacijentiRepository', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PacijentiRepositoryService]
    });
  });

  it('should ...', inject([PacijentiRepositoryService], (service: PacijentiRepositoryService) => {
    expect(service).toBeTruthy();
  }));
});
