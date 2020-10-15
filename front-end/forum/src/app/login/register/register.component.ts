import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseDestroyableComponent } from 'src/app/core/base-classes/base-destroyable';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent extends BaseDestroyableComponent implements OnInit, OnDestroy {

  form: FormGroup;

  constructor(private fb: FormBuilder,
              private router: Router,
              private activatedRoute: ActivatedRoute) {
    super();
  }

  ngOnInit(): void {
    this.createForm();
  }

  submit(): void {
    console.log('submitted:', this.form.value);
  }

  cancel(): void {
    this.router.navigate(['../login'], { relativeTo: this.activatedRoute });
  }

  private createForm(): void {
    this.form = this.fb.group({
      login: '',
      password: ''
    });
  }

}
