import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PostRoutingModule } from './post-routing.module';
import { PostComponent } from './post.component';
import { PostLandingComponent } from './post-landing/post-landing.component';


@NgModule({
  declarations: [PostComponent, PostLandingComponent],
  imports: [
    CommonModule,
    PostRoutingModule
  ]
})
export class PostModule { }
