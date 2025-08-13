import {Component, OnInit} from '@angular/core';
import {AuthService} from "../shared/services/auth.service";
import { Router } from '@angular/router';
import { AutentifikacijaHelper } from '../_helpers/autentifikacija-helper';

@Component({
  selector: 'app-unauthorized',
  templateUrl: './unauthorized.component.html',
  styleUrls: ['./unauthorized.component.css']
})
export class UnauthorizedComponent {
  public isUserAuthenticated: boolean = false;
  constructor(private router: Router) {
    this.isUserAuthenticated = AutentifikacijaHelper.getLoginInfo().isLogiran;
  }
  public login = () => {
    this.router.navigateByUrl('/login');
  }

}
