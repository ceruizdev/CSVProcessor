import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { CSVBody } from 'src/resources/models/CSVBody';

@Injectable({
  providedIn: 'root'
})
export class CSV {

  constructor(private http: HttpClient) { }

  processFile(object: CSVBody) {
    const filter = this.getParams({object});
    const ruteApi = `${environment.url_api}/BankMovement`;
    return this.http.get<CSVBody>(ruteApi, {
      params: filter});
  }

  getAll() {
    const ruteApi = `${environment.url_api}/getAll`;
    return this.http.get<CSVBody[]>(ruteApi);
  }

  getParams(obj: any): HttpParams {
    return Object.keys(obj).reduce((params, key) =>
      obj[key] ? params.append(key, obj[key]) : params, new HttpParams());
  }
}
