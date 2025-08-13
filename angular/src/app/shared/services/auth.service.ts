import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { AutentifikacijaHelper } from 'src/app/_helpers/autentifikacija-helper';
import { LoginInformacije } from 'src/app/_helpers/login-informacije';
import { ToastService } from 'src/app/ngToastService/toast.service';
import { Constants } from '../constants';
import { Korisnik } from 'src/app/Models/Korisnik';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private _loginChangedSubject = new Subject<boolean>();
  public loginChanged = this._loginChangedSubject.asObservable();
  private _user: Korisnik;

  constructor(private httpKlijent: HttpClient, private router: Router, private toast: ToastService) {
  }

  public isAuthenticated = (): boolean => {
    const loginInfo = this.getLoginInfo();
    var user = loginInfo.authToken.korisnik;
    if (this._user !== user) {
      this._loginChangedSubject.next(loginInfo.isLogiran);
    }
    this._user = user;

    return loginInfo.isLogiran;
  }
  public getLoginInfo = (): LoginInformacije => {
    return AutentifikacijaHelper.getLoginInfo();
  }
  public login = () => {
      this.router.navigateByUrl("/login");
  }
  public finishLogin = () => {
    this._loginChangedSubject.next(true);
  }
  public logout = () => {
    AutentifikacijaHelper.setLoginInfo(null);

    this.httpKlijent.post(Constants.apiRoot + "Auth/Logout/", null)
      .subscribe((x: any) => {
        this.finishLogout();
        this.login();
        this.toast.showSuccess('Odjava uspjesna');
      });
  }
  public finishLogout = () => {
    this._loginChangedSubject.next(false);
  }
  public getAccessToken = (): string => {
    return this.getLoginInfo().authToken ? this.getLoginInfo().authToken.token : null;
  }

  public GetUserId = (): string => {
    return this.getLoginInfo().authToken ? this.getLoginInfo().authToken.korisnikId : null;
  }

  public checkIfUser2FAIsAllowed = (): Promise<boolean> => {
    return Promise.resolve(this.getLoginInfo().authToken.isAllowed2FA);
  }
  public checkIfUserIsAdmin = (): Promise<boolean> => {
    return Promise.resolve(this.getLoginInfo().isPermisijaAdmin);
  }
  public checkIfUserIsFarmaceut = (): Promise<boolean> => {
    return Promise.resolve(this.getLoginInfo().isPermisijaFarmaceut);
  }
  public checkIfUserIsLjekar = (): Promise<boolean> => {
    return Promise.resolve(this.getLoginInfo().isPermisijaLjekar);
  }

  public checkIfUserIsPacijent = (): Promise<boolean> => {
    return Promise.resolve(this.getLoginInfo().isPermisijaPacijent);
  }

  public checkIfUserIsAsistent = (): Promise<boolean> => {
    return Promise.resolve(this.getLoginInfo().isPermisijaAsistent);
  }

  public checkIfUserIsTehnicar = (): Promise<boolean> => {
    return Promise.resolve(this.getLoginInfo().isPermisijaTehnicar);
  }
}
