import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Visor de archivos CSV';
  constructor(private router: Router, private cookieService: CookieService){}
  
  ngOnInit(): void {
    this.activeSesion();
  }
  
  
  closeSesion(){
    this.cookieService.deleteAll()
    this.router.navigateByUrl("/login")
  }

  activeSesion(){
    const token = this.cookieService.get('token');
    return !token ? false : true;
  }
}
