import { Component, OnInit } from '@angular/core';
import { AuthService } from './shared/services/auth.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'HealthCare';
  public userAuthenticated = false;
  constructor(private _authService: AuthService, private translateService: TranslateService) {
    this.translateService.setDefaultLang('bos');
    this.translateService.use(localStorage.getItem('lang') || 'bos');
    
    this._authService.loginChanged
      .subscribe(userAuthenticated => {
        this.userAuthenticated = userAuthenticated;
      })
  }

  ngOnInit(): void {
    this.userAuthenticated = this._authService.isAuthenticated();
  }
}
