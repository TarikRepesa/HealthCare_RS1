/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { NalaziRepositoryService } from './nalazi-repository.service';

describe('Service: NalaziRepository', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [NalaziRepositoryService]
    });
  });

  it('should ...', inject([NalaziRepositoryService], (service: NalaziRepositoryService) => {
    expect(service).toBeTruthy();
  }));
});
