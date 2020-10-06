import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { NewsService } from '../services/news.service';
import { Post } from '../models/post';

import {AuthenticationService} from '../services/authentication.service' ;

@Component({
  selector: 'app-single-post',
  templateUrl: './single-post.component.html',
  styleUrls: ['./single-post.component.scss']
})
export class SinglePostComponent implements OnInit {
  singlePost$: Observable<Post>;
  postId: number;

  constructor(private newsService: NewsService, private avRoute: ActivatedRoute, private router: Router) {
    const idParam = 'id';
    if (this.avRoute.snapshot.params[idParam]) {
      this.postId = this.avRoute.snapshot.params[idParam];
    }
  }

  ngOnInit() {
    this.loadPost();
  }

  loadPost() {
    this.singlePost$ = this.newsService.getPost(this.postId);
  }
  cancel() {
    this.router.navigate(['/']);
  }
}