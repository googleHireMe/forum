import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { baseUrl, storage } from '../../core/consts/consts';
import { LoginCredentials } from '../../login/models/login-credentials';
import { RegisterCredentials } from '../../login/models/register-credentials';
import { tap } from 'rxjs/operators';
import { LocalStorageService } from './local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private _isAuthenticated$: BehaviorSubject<boolean>;

  get isAuthenticated$(): Observable<boolean> {
    return this._isAuthenticated$.asObservable();
  }

  constructor(private httpClient: HttpClient,
              private localStorageService: LocalStorageService) {
    this._isAuthenticated$ = new BehaviorSubject<boolean>(this.isAuthenticated());
  }

  login(credentials: LoginCredentials): Observable<any> {
    return this.httpClient.post(`${baseUrl}/login`, credentials)
      .pipe(
        tap(_ => this.localStorageService.storage.setItem(storage.isLoggedIn, 'true')),
        tap(_ => this._isAuthenticated$.next(true))
      );
  }

  logout(): Observable<any> {
    return this.httpClient.post(`${baseUrl}/logout`, null)
      .pipe(
        tap(_ => this._isAuthenticated$.next(false))
      );
  }

  register(credentials: RegisterCredentials): Observable<any> {
    return this.httpClient.post(`${baseUrl}/register`, credentials);
  }

  isAuthenticated(): boolean {
    debugger;
    const result = JSON.parse(this.localStorageService.storage.getItem(storage.isLoggedIn)) as boolean;
    return result;
  }

}
