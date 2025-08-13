import { Component, OnInit } from '@angular/core';
import { AuthService } from '../shared/services/auth.service';
import { HttpClient } from '@angular/common/http';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';
import { SignalRService } from '../SignalR/signalR.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  public isUserAuthenticated: boolean = false;
  public isUserAdmin: boolean = false;

  currentUser: any;
  currentrole: any;
  userId: any;

  lang: any;
  loginMessage: any;
  errorMessage: any;

  constructor(private _authService: AuthService, private http: HttpClient, private url: EnvironmentUrlService, public signalRService: SignalRService,
    private translate: TranslateService) {
  }

  ngOnInit(): void {
    this.lang = localStorage.getItem('lang') || 'bos';

    this.translateMessage();
    this.signalRService.startConnection();

    this._authService.loginChanged
      .subscribe(res => {
        this.isUserAuthenticated = res;
        this.isAdmin();

        if (this.isUserAuthenticated) {
            this._authService.checkIfUser2FAIsAllowed()
            .then(user2FAIsAllowed => {
              if(user2FAIsAllowed) {
                this.getUserId();
                this.getUser();
              }
            });
        }
      })

    this._authService.isAuthenticated();
    this.authMeListenerSuccess();
    this.authMeListenerFail();
  }

  private translateMessage() {
    this.translate.get('LOGIN_MESSAGE').subscribe((translatedText: string) => {
      this.loginMessage = translatedText;
    });

    this.translate.get('LOGIN_ERROR').subscribe((translatedText: string) => {
      this.errorMessage = translatedText;
    });
  }

  public login = () => {
    this._authService.login();
  }

  public logout = () => {
    this._authService.logout();
  }

  changeLang(lang: any) {
    localStorage.setItem('lang', lang.target.value);
    window.location.reload();
  }

  getUserId() {
    this.userId = this._authService.GetUserId();
    this.authMe(this.userId);
  }

  public isAdmin = () => {
    return this._authService.checkIfUserIsAdmin()
      .then(res => {
        this.isUserAdmin = res;
      })
  }

  async authMe(userId: string) {
    await this.signalRService.hubConnection.invoke("authMe", userId)
      .catch(err => console.error(err));
  }

  authMeListenerSuccess() {
    this.signalRService.hubConnection.on("authMeResponseSuccess", (userName: string) => {
      this.signalRService.toast.showSuccess(this.loginMessage + " " + userName);
    });
  }

  authMeListenerFail() {
    this.signalRService.hubConnection.on("authMeResponseFail", () => {
      this.signalRService.toast.showError(this.errorMessage);
    });
  }

  getUser() {
    this.http.get(this.url.urlAddress + '/Korisnik/GetLogiraniKorisnik')
      .subscribe((result: any) => {
        this.currentUser = result;
      });
  }
}
