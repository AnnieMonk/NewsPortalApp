import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Account } from '../models/account';
import { retry, catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient) { }

  login( username: string, password: string): Observable<any>{

    return this.http.post<any>('https://localhost:44315/api/Account/Login/', {username, password})
    .pipe(map(user => {
      if (user){
        user.authdata = window.btoa(username + ':' + password);
        localStorage.setItem('currentUser', JSON.stringify(user));
      }

      return user;
    }));
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
    
}
  getLoggedUser(): Observable<Account>{
    return this.http.get<Account>('https://localhost:44315/api/Account/GetLoggedUser')
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
  }

  getById(accountId: number) : Observable<Account>{
    return this.http.get<Account>('https://localhost:44315/api/Account/' + accountId)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );

  }

  errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }   
}
