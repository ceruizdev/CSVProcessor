import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { CSVBody } from 'src/resources/models/CSVBody';
import { ProcessedFile } from 'src/resources/models/procesedFile';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class CSV {

  constructor(private http: HttpClient, private cookieService: CookieService) { }

  processFile(model: CSVBody) {
    const ruteApi = `${environment.url_api}/create`;
    return this.http.post<CSVBody>(ruteApi, model, {headers: new HttpHeaders(
      {
        'Authorization': `Bearer ${this.cookieService.get('token')}` ,
         'Content-Type': 'application/json'
            })
      });
  }

  getAll() {
    
    const ruteApi = `${environment.url_api}/getAll`;
    return this.http.get<CSVBody[]>(ruteApi, {headers: new HttpHeaders(
      {
        'Authorization': `Bearer ${this.cookieService.get('token')}` ,
         'Content-Type': 'application/json'
            })
      });
  }

  processString(CSV: CSVBody) {
    const ruteApi = `${environment.url_api}/processString`;
    return this.http.post<ProcessedFile>(ruteApi, CSV, {headers: new HttpHeaders(
      {
        'Authorization': `Bearer ${this.cookieService.get('token')}` ,
         'Content-Type': 'application/json'
            })
      });
  }

  deleteDocument(id: number) {
    const ruteApi = `${environment.url_api}/delete/${id}`;
    return this.http.delete(ruteApi, {headers: new HttpHeaders(
      {
        'Authorization': `Bearer ${this.cookieService.get('token')}` ,
         'Content-Type': 'application/json'
            })
      });
  }

  getParams(obj: any): HttpParams {
    return Object.keys(obj).reduce((params, key) =>
      obj[key] ? params.append(key, obj[key]) : params, new HttpParams());
  }
}
