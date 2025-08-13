import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { ActivatedRoute, Router } from "@angular/router";
import { AutentifikacijaHelper } from "../_helpers/autentifikacija-helper";
import { LoginInformacije } from "../_helpers/login-informacije";
import { Constants } from '../shared/constants';
import { ToastService } from '../ngToastService/toast.service';
import { AuthService } from '../shared/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  txtLozinka: any;
  txtEmail: any;
  route: ActivatedRoute;

  posaljiPonovoAktivaciju: boolean;

  constructor(private httpKlijent: HttpClient, private router: Router, route: ActivatedRoute, private toast: ToastService, private authService: AuthService) {
    this.route = route;
  }

  ngOnInit(): void {

    this.route.queryParams
      .subscribe(params => {
        if ('email' in params && 'kod' in params) {
          this.httpKlijent.post<boolean>(Constants.apiRoot + "Korisnik/AktivacijaNaloga", {
            email: params['email'],
            kod: params['kod']
          })
            .subscribe({
              next: (x: boolean) => {
                this.toast.showSuccess("Račun uspješno aktiviran");
                this.txtEmail = params['email'];
              },
              error: (err: HttpErrorResponse) => {
                this.toast.showError(err.message);
              }

            });
        }
      }
      );
  }

  frmSubmit() {
    let data = {
      email: this.txtEmail,
      lozinka: this.txtLozinka
    };
    this.httpKlijent.post<LoginInformacije>(Constants.apiRoot + "Auth/Login", data)
      .subscribe((x: LoginInformacije) => {
        if (x.isLogiran) {
          AutentifikacijaHelper.setLoginInfo(x);
          this.authService.finishLogin();

          if (x.authToken.isAllowed2FA) {
            this.toast.showSuccess("Prijava uspješna");
            this.router.navigateByUrl("/");
          } else {
            // Redirekcija na 2FA formu
            this.toast.showInfo("Ispunite formu za dvostruku autentifikaciju");
            this.router.navigateByUrl("/twofactor-login");
          }
        // } else if (x.authToken && !x.authToken.korisnik.isAktivan) {
        //   porukaError("Račun nije aktiviran, provjerite poštu");
        //   this.posaljiPonovoAktivaciju = true;
        } else {
          AutentifikacijaHelper.setLoginInfo(null)
          this.toast.showError("Prijava neuspješna");
        }
      });
  }


  onEmailChange($event: Event) {
    this.posaljiPonovoAktivaciju = false;
  }

  ponovoPosaljiAktivaciju() {
    this.httpKlijent.post<boolean>(Constants.apiRoot + "Korisnik/PosaljiAktivaciju", { email: this.txtEmail })
      .subscribe({
        next: (x: boolean) => {
          this.toast.showSuccess("Email uspješno poslan");
        },
        error: (err: HttpErrorResponse) => {
          this.toast.showError(err.message);
        }

      });
  }
}
