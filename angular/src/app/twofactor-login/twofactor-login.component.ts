import {Component, OnInit} from '@angular/core';
import {HttpClient, HttpErrorResponse} from "@angular/common/http";
import {Router} from "@angular/router";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";
import {LoginInformacije} from "../_helpers/login-informacije";
import { Constants } from '../shared/constants';
import { AuthService } from '../shared/services/auth.service';
import { ToastService } from '../ngToastService/toast.service';

@Component({
  selector: 'app-twofactor-login',
  templateUrl: './twofactor-login.component.html',
  styleUrls: ['./twofactor-login.component.css']
})
export class TwoFactorLoginComponent implements OnInit {
  txtVerificationCode: any;

  constructor(private httpKlijent: HttpClient, private router: Router, private authService: AuthService, private toast: ToastService) {
  }

  ngOnInit(): void { }

  frmSubmit() {
    let data = {
      VerificationCode: this.txtVerificationCode,
    };
    this.httpKlijent.post<LoginInformacije>(Constants.apiRoot + "Auth/Login2FA", data)
      .subscribe(
        {
          next: (x: LoginInformacije) => {
            if (x.isLogiran && x.authToken.isAllowed2FA) {
              this.toast.showSuccess("Prijava uspješna");
              AutentifikacijaHelper.setLoginInfo(x);
              this.authService.finishLogin();
              this.router.navigateByUrl("/");
            } else {
              this.toast.showError("Neočekivana greška");
            }
          },
          error: (err: HttpErrorResponse) => {
            this.toast.showError("Provjera neuspješna, provjerite kod");
          }

      });
  }

  ponisti() {
    this.router.navigate(['login']);
  }
}
