import { Component } from '@angular/core';
import { InventoryItemService } from '../services/InventoryItem.service';
import { InventoryItem } from 'src/models/InventoryItem';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-fetch-item',
  templateUrl: './fetch-item.component.html',
  styleUrls: ['./fetch-item.component.css']
})
export class FetchItemComponent {
  ItemId: number;
  public item: InventoryItem[];

  constructor(private _itemService: InventoryItemService, private _avRoute: ActivatedRoute) {
    if (this._avRoute.snapshot.params['id']) {
      this.ItemId = this._avRoute.snapshot.params['id'];
    }
    this.getItemDetails(this.ItemId);
  }
  getItemDetails(itemId: any) {
    this._itemService.getItemById(itemId).subscribe(
      (data: InventoryItem[]) => this.item = data
    );
  }
 
}
