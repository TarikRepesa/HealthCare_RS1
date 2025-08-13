/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AsistentiRepositoryService } from './asistenti-repository.service';

describe('Service: AsistentiRepository', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AsistentiRepositoryService]
    });
  });

  it('should ...', inject([AsistentiRepositoryService], (service: AsistentiRepositoryService) => {
    expect(service).toBeTruthy();
  }));
});
