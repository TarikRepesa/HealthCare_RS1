import { Injectable } from '@angular/core';
import {
  HttpErrorResponse,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest
} from "@angular/common/http";
import {from, Observable} from "rxjs";
import {AuthService} from "./auth.service";
import {Router} from "@angular/router";
import { catchError } from 'rxjs/operators'
import { Constants } from '../constants';

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptorService implements HttpInterceptor  {

  constructor(private _authService: AuthService, private _router: Router) { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if(req.url.startsWith(Constants.apiRoot)){
      var token = this._authService.getAccessToken();
      const headers = req.headers.set('Authorization', `${token}`);
      const authRequest = req.clone({ headers });

      return next.handle(authRequest)
        .pipe(
          catchError((err: HttpErrorResponse) => {
            if(err && (err.status === 401 || err.status === 403)){
              this._router.navigate(['/unauthorized']);
            }
            throw 'error in a request ' + err.status;
          })
      )
    }
    else {
      return next.handle(req);
    }
  }
}
