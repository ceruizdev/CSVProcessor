import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from 'src/resources/models/user';
import { UserLogin } from 'src/resources/models/userLogin';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }

  login(model: UserLogin){
    const ruteApi = `${environment.url_api}/login`;
    return this.http.post<User>(ruteApi, model);
  }
}
