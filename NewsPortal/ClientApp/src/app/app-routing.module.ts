import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PostsComponent } from './posts/posts.component';
import { SinglePostComponent } from './single-post/single-post.component';
import { SinglePostUpsertComponent } from './single-post-upsert/single-post-upsert.component';
import { LoginComponent } from './login/login.component';


const routes: Routes = [
  { path: '', component: PostsComponent, pathMatch: 'full'}, // odmah na pocetku se ucita
  { path: 'singlepost/:id', component: SinglePostComponent },
  { path: 'add', component: SinglePostUpsertComponent },
  { path: 'singlepost/edit/:id', component: SinglePostUpsertComponent },
  { path: 'login', component: LoginComponent},
  { path: '**', redirectTo: '/' } // sve invalid putanje ce btii redirected na startpage
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
