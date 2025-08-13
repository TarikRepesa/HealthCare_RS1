/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { NalaziPregledRepositoryService } from './nalazi-pregled-repository.service';

describe('Service: NalaziRepository', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [NalaziPregledRepositoryService]
    });
  });

  it('should ...', inject([NalaziPregledRepositoryService], (service: NalaziPregledRepositoryService) => {
    expect(service).toBeTruthy();
  }));
});
