import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseDestroyableComponent } from 'src/app/core/base-classes/base-destroyable';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent extends BaseDestroyableComponent implements OnInit, OnDestroy {

  form: FormGroup;

  constructor(private fb: FormBuilder,
              private router: Router,
              private activatedRoute: ActivatedRoute) {
    super();
  }

  ngOnInit(): void {
    this.createForm();
  }

  submit() {
    console.log('submitted:', this.form.value);
  }

  register(): void {
    this.router.navigate(['../register'], { relativeTo: this.activatedRoute });
  }

  private createForm(): void {
    this.form = this.fb.group({
      login: '',
      password: ''
    });
  }

}
