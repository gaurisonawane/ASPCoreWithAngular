import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { InventoryItemService } from '../services/InventoryItem.service';
import { InventoryItem } from 'src/models/InventoryItem';

@Component({
  selector: 'app-add-item',
  templateUrl: './add-item.component.html',
  styleUrls: ['./add-item.component.css']
})
export class AddItemComponent implements OnInit {

  InventoryItemForm: FormGroup;
  title = 'Create';
  ItemId: number;
  errorMessage: any;
  public itemList: InventoryItem[];

  constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
    private _itemService: InventoryItemService, private _router: Router) {
    if (this._avRoute.snapshot.params['id']) {
      this.ItemId = this._avRoute.snapshot.params['id'];
    }

    this.InventoryItemForm = this._fb.group({
      ItemId: 0,
      Name: ['', [Validators.required]],
      Description: ['', [Validators.required]],
      Price: ['', [Validators.required]]
    })

    this.getItems();
  }

  ngOnInit() {
  }

  getItems() {
    this._itemService.getItems().subscribe(
      (data: InventoryItem[]) => this.itemList = data
    );
  }

  delete(itemID) {
    const ans = confirm('Do you want to delete item with Id: ' + itemID);
    if (ans) {
      this._itemService.deleteItem(itemID).subscribe(() => {
        this.getItems();
      }, error => console.error(error));
    }
    this._router.navigate(['/register-item']);
  }

  getDetails(itemId: any) {
    this._router.navigate(['/fetch-item/' + itemId]);
  }
  save() {

    if (!this.InventoryItemForm.valid) {
      return;
    }
    this._itemService.saveItem(this.InventoryItemForm.value)
        .subscribe(() => {
          this._router.navigate(['/fetch-item']);
        }, error => console.error(error));
  }

  cancel() {
    this._router.navigate(['/fetch-item']);
  }

  get Name() { return this.InventoryItemForm.get('Name'); }
  get Description() { return this.InventoryItemForm.get('Description'); }
  get Price() { return this.InventoryItemForm.get('Price'); }
}
