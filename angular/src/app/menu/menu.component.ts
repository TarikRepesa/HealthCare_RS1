import { Component, OnInit } from '@angular/core';
import { AuthService } from '../shared/services/auth.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  public isUserAuthenticated: boolean = false;
  public isUserAllowed2FA: boolean = false;
  public isUserAdmin: boolean = false;
  public isUserManager: boolean = false;
  public isUserFarmaceut: boolean = false;
  public isUserLjekar: boolean = false;
  public isUserPacijent: boolean = false;
  public isUserAsistent: boolean = false;
  public isUserTehnicar: boolean = false;

  constructor(private _authService: AuthService) { }
  ngOnInit(): void {
    this._authService.loginChanged
      .subscribe(res => {
        this.isUserAuthenticated = res;
        this.isAllowed2FA();
        this.isAdmin();
        this.isFaramaceut();
        this.isLjekar();
        this.isPacijent();
        this.isAsistent();
        this.isTehnicar();
      });

    this._authService.isAuthenticated();
  }
  public login = () => {
    this._authService.login();
  }
  public logout = () => {
    this._authService.logout();
  }
  public isAllowed2FA = () => {
    return this._authService.checkIfUser2FAIsAllowed()
      .then(res => {
        this.isUserAllowed2FA = res;
      })
  }
  public isAdmin = () => {
    return this._authService.checkIfUserIsAdmin()
      .then(res => {
        this.isUserAdmin = res;
      })
  }
  public isFaramaceut = () => {
    return this._authService.checkIfUserIsFarmaceut()
      .then(res => {
        this.isUserFarmaceut = res;
      })
  }
  public isLjekar = () => {
    return this._authService.checkIfUserIsLjekar()
      .then(res => {
        this.isUserLjekar = res;
      })
  }

  public isPacijent = () => {
    return this._authService.checkIfUserIsPacijent()
      .then(res => {
        this.isUserPacijent = res;
      })
  }

  public isAsistent = () => {
    return this._authService.checkIfUserIsAsistent()
      .then(res => {
        this.isUserAsistent = res;
      })
  }

  public isTehnicar = () => {
    return this._authService.checkIfUserIsTehnicar()
      .then(res => {
        this.isUserTehnicar = res;
      })
  }
}
