import { TestBed } from '@angular/core/testing';

import { FunilService } from './funil.service';

describe('FunilService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: FunilService = TestBed.get(FunilService);
    expect(service).toBeTruthy();
  });
});
