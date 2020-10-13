import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Topic } from '../models/topic';

@Component({
  selector: 'app-topic-list',
  templateUrl: './topic-list.component.html',
  styleUrls: ['./topic-list.component.scss']
})
export class TopicListComponent implements OnInit {

  topics: Topic[];

  constructor(private router: Router,
              private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
  }

  onTopicClick(id: string): void {
    this.router.navigate(['./topic', id], { relativeTo: this.activatedRoute });
  }

  onCreateTopicClick(): void {
    this.router.navigate(['../create-topic'], { relativeTo: this.activatedRoute });
  }

}
