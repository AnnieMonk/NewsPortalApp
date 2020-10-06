import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { NewsService } from '../services/news.service';
import { Post } from '../models/post';
import { Account } from '../models/account';
import { AuthenticationService } from '../services/authentication.service';

@Component({
  selector: 'app-single-post-upsert',
  templateUrl: './single-post-upsert.component.html',
  styleUrls: ['./single-post-upsert.component.scss']
})
export class SinglePostUpsertComponent implements OnInit {
  form: FormGroup;
  actionType: string;
  formTitle: string;
  formContent: string;
  postId: number;
  errorMessage: any;
  existingPost: Post;

  public informationData;

  constructor(private newsService: NewsService, 
    private formBuilder: FormBuilder, private avRoute: ActivatedRoute, private router: Router) {
    const idParam = 'id';
    this.actionType = 'Add';
    this.formTitle = 'title';
    this.formContent = 'content';
    if (this.avRoute.snapshot.params[idParam]) {
      this.postId = this.avRoute.snapshot.params[idParam];
    }

    this.form = this.formBuilder.group(
      {
        postId: 0,
        title: ['', [Validators.required]],
        content: ['', [Validators.required]],
      }
    )
  }

  ngOnInit() {

    if (this.postId > 0) {
      this.actionType = 'Edit';
      this.newsService.getPost(this.postId)
        .subscribe(data => {
          this.informationData = data;
          this.existingPost = this.informationData,
          console.log(this.existingPost);
          this.form.controls[this.formTitle].setValue(this.informationData.title),
          this.form.controls[this.formContent].setValue(this.informationData.content);
        });

      
    }
  }

  save() {
    if (!this.form.valid) {
      return;
    }
    let json = JSON.parse(localStorage.getItem('currentUser'));
    
    if (this.actionType === 'Add') {
      
      let post: Post = {
        PublishDate: new Date(),
        AccountId: json.accountId,
        Title: this.form.get(this.formTitle).value,
        Content: this.form.get(this.formContent).value,
        Account: json
      };

      this.newsService.savePost(post)
        .subscribe(data => {
          this.informationData = data;
         
          this.router.navigate(['/singlepost', this.informationData.postId]);
        });
    }


    if (this.actionType === 'Edit') {
      
      this.informationData = this.existingPost;
      let post: Post = {
        PostId: this.informationData.postId,
        PublishDate: this.informationData.publishDate,
        AccountId: this.informationData.accountId,
        Title: this.form.get(this.formTitle).value,
        Content: this.form.get(this.formContent).value,
        Account: this.informationData.account
      };
      console.log(post);
      this.newsService.updatePost(post.PostId, post)
        .subscribe(data => {
          this.informationData = data;
          this.router.navigate(['/singlepost', this.informationData.postId]);
        });
    }
  }

  cancel() {
    this.router.navigate(['/']);
  }

  get title() { return this.form.get(this.formTitle); }
  get content() { return this.form.get(this.formContent); }
}