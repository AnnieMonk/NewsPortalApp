import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { NewsService } from '../services/news.service';
import { AuthenticationService } from '../services/authentication.service';
import { Post } from '../models/post';
import { Account } from '../models/account';
import {AfterViewInit, ElementRef, ViewChild} from '@angular/core';


@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.scss']
})
export class PostsComponent implements OnInit {
  @ViewChild('actionsId') myDiv: ElementRef;
  newsPosts$: Observable<Post[]>;
  username: string;
  term: string;
  public informationData;
  constructor(private newsService: NewsService, private authService: AuthenticationService) {
    this.username = ' ';
  }
  ngOnInit(): void {
    this.loadPosts();
    this.getLoggedUser();
  }

  loadPosts(): void {
    if(this.isLogged()){
      let json = JSON.parse(localStorage.getItem('currentUser'));
      this.newsPosts$ = this.newsService.getAllPosts(json.username);
    }
    else{
      this.newsPosts$ = this.newsService.getAllPosts(null);
    }
    
  }
  isLogged(): boolean{
    if (JSON.parse(localStorage.getItem('currentUser')) != null){
      return true;
    }
    return false;
  }

  getLoggedUser(): void{
   let json = JSON.parse(localStorage.getItem('currentUser'));
   console.log(json);
   if (json != null) {
    this.username = json.username;
   }

  }

  logOut(): void{
    this.authService.logout();
    this.username = ' ';
    this.loadPosts();
  }

  delete(postId): void {
    const ans = confirm('Do you want to delete post with id: ' + postId);
    if (ans) {
      this.newsService.deletePost(postId).subscribe((data) => {
        this.loadPosts();
      });
    }
  }
}