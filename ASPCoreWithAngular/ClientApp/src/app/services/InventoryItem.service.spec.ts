import { TestBed } from '@angular/core/testing';

import { InventoryItemService } from './InventoryItem.service';

describe('InventoryItemService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: InventoryItemService = TestBed.get(InventoryItemService);
    expect(service).toBeTruthy();
  });
});
