import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Ng2SearchPipeModule } from 'ng2-search-filter';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PostsComponent } from './posts/posts.component';
import { SinglePostComponent } from './single-post/single-post.component';
import { SinglePostUpsertComponent } from './single-post-upsert/single-post-upsert.component';
import { NewsService } from './services/news.service';
import { LoginComponent } from './login/login.component';
import { BasicAuthInterceptor} from './helper/basicauthinterceptor';

@NgModule({
  declarations: [
    AppComponent,
    PostsComponent,
    SinglePostComponent,
    SinglePostUpsertComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    Ng2SearchPipeModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    
  ],
  providers: [
    NewsService,
    {provide: HTTP_INTERCEPTORS, useClass: BasicAuthInterceptor, multi: true }
  ],
  
  bootstrap: [AppComponent]
})
export class AppModule { }
