import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BaseDestroyableComponent } from 'src/app/core/base-classes/base-destroyable';

@Component({
  selector: 'app-create-topic',
  templateUrl: './create-topic.component.html',
  styleUrls: ['./create-topic.component.scss']
})
export class CreateTopicComponent extends BaseDestroyableComponent implements OnDestroy {

  form: FormGroup;

  constructor(private fb: FormBuilder) {
    super();
  }

  ngOnInit(): void {
    this.createForm();
  }

  submit() {
    console.log('submitted:', this.form.value);
  }

  private createForm(): void {
    this.form = this.fb.group({
      content: ''
    });
  }

}
