import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Post } from '../models/post';

@Injectable({
  providedIn: 'root'
})
export class NewsService {

  myAppUrl: string;
  myApiUrl: string; 
  posts: Observable<Post[]>;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient) {
      this.myAppUrl = environment.appUrl;
      this.myApiUrl = 'api/Post/';
  }

  getAllPosts(username: string): Observable<Post[]> {
    if(username != null){
      return this.http.get<Post[]>(this.myAppUrl + this.myApiUrl + '?Username=' + username)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
    }
    else{
      return this.http.get<Post[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
    }
   
    
  }

  getPost(postId: number): Observable<Post> {
      return this.http.get<Post>('https://localhost:44315/api/Post/' + postId)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  savePost(post): Observable<Post> {
      return this.http.post<Post>('https://localhost:44315/api/Post/', JSON.stringify(post), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  updatePost(PostId: number, post): Observable<Post> {
      return this.http.put<Post>('https://localhost:44315/api/Post/' + PostId, JSON.stringify(post), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  deletePost(postId: number): Observable<Post> {
      return this.http.delete<Post>('https://localhost:44315/api/Post/' + postId)
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