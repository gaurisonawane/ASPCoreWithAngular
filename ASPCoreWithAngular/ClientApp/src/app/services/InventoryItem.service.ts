import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { InventoryItem } from 'src/models/InventoryItem';

@Injectable({
  providedIn: 'root'
})
export class InventoryItemService {

  myAppUrl = '';

  constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl + 'api/InventoryItem/';
  }

  getItems() {
    return this._http.get(this.myAppUrl + 'Index').pipe(map(
      response => {
        return response;
      }));
  }

  getItemById(id: number) {
    return this._http.get(this.myAppUrl + 'Details/' + id)
      .pipe(map(
        response => {
          return response;
        }));
  }

  saveItem(item: InventoryItem) {
    return this._http.post(this.myAppUrl + 'Create', item)
      .pipe(map(
        response => {
          return response;
        }));
  }


  deleteItem(id: number) {
    return this._http.delete(this.myAppUrl + 'Delete/' + id)
      .pipe(map(
        response => {
          return response;
        }));
  }
}
