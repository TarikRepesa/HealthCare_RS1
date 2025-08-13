/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { TerminiRepositoryService } from './termini-repository.service';

describe('Service: TerminiRepository', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TerminiRepositoryService]
    });
  });

  it('should ...', inject([TerminiRepositoryService], (service: TerminiRepositoryService) => {
    expect(service).toBeTruthy();
  }));
});
