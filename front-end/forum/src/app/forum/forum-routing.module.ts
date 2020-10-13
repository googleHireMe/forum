import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateTopicComponent } from './create-topic/create-topic.component';
import { ScreenComponent } from './screen/screen.component';
import { TopicListComponent } from './topic-list/topic-list.component';
import { TopicComponent } from './topic/topic.component';

const routes: Routes = [
  {
    path: 'forum',
    component: ScreenComponent,
    children: [
      {
        path: 'topics',
        component: TopicListComponent
      },
      {
        path: 'topic/:id',
        component: TopicComponent
      },
      {
        path: 'create-topic',
        component: CreateTopicComponent
      },
      { path: '', redirectTo: 'topics', pathMatch: 'full' },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ForumRoutingModule { }