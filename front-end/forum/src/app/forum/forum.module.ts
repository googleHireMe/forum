import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ScreenComponent } from './screen/screen.component';
import { MessageComponent } from './message/message.component';
import { CreateTopicComponent } from './create-topic/create-topic.component';
import { TopicComponent } from './topic/topic.component';
import { ForumRoutingModule } from './forum-routing.module';
import { TopicListComponent } from './topic-list/topic-list.component';
import { MaterialModule } from '../material/material.module';
import { ReactiveFormsModule } from '@angular/forms';




@NgModule({
  declarations: [
    ScreenComponent,
    MessageComponent,
    CreateTopicComponent,
    TopicComponent,
    TopicListComponent
  ],
  imports: [
    CommonModule,
    ForumRoutingModule,
    MaterialModule,
    ReactiveFormsModule
  ]
})
export class ForumModule { }
