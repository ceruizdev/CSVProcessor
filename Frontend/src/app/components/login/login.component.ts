import { Component, OnInit } from '@angular/core';
import { Form, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { UserLogin } from 'src/resources/models/userLogin';
import { LoginService } from 'src/resources/services/login/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form!: FormGroup;
  constructor(private fb: FormBuilder,
              private loginService: LoginService,
              private cookieService: CookieService,
              private router: Router) { }

  ngOnInit(): void {
    this.initForm();
  }

  initForm(){
    this.form = this.fb.group({
      userName: ['', Validators.required],
      password: ['', Validators.required]
    })
  }

  login(){
    const user: UserLogin = {
      userName: this.userName?.value,
      password: this.password?.value
    }
    this.loginService.login(user).subscribe(resp => {
      this.cookieService.set('token', resp.token);
      console.log(resp);
      this.router.navigateByUrl('/')
    })
  }

  get userName() {
    return this.form.get('userName');
  }

  get password() {
    return this.form.get('password');
  }
}
