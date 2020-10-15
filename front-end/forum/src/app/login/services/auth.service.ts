import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from 'src/app/core/consts/consts';
import { LoginCredentials } from '../models/login-credentials';
import { RegisterCredentials } from '../models/register-credentials';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient: HttpClient) { }

  login(credentials: LoginCredentials): Observable<any> {
    return this.httpClient.post(`${baseUrl}/login`, credentials);
  }

  logout(): Observable<any> {
    return this.httpClient.post(`${baseUrl}/logout`, null);
  }

  register(credentials: RegisterCredentials): Observable<any> {
    return this.httpClient.post(`${baseUrl}/register`, credentials);
  }


}
