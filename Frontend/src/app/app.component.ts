import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Visor de archivos CSV';
  constructor(private router: Router, private cookieService: CookieService){}
  closeSesion(){
    this.cookieService.deleteAll()
    this.router.navigateByUrl("/login")
  }
}
