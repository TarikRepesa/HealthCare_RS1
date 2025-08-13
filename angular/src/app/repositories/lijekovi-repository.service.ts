import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Lijek } from "../interfaces/lijek";
import { EnvironmentUrlService } from "../shared/services/environment-url.service";
import { AuthService } from "../shared/services/auth.service";
import { from } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class LijekoviRepositoryService {
  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService, private _authService: AuthService) { }
  public getLijekovi = (route: string) => {
    return this.http.get(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }
  public createLijek = (route: string, lijek: any) => {
    return this.http.post<Lijek>(this.createCompleteRoute(route, this.envUrl.urlAddress), lijek, this.generateHeaders());
  }
  public updateLijek = (route: string, lijek: Lijek) => {
    return this.http.post(this.createCompleteRoute(route, this.envUrl.urlAddress), lijek, this.generateHeaders());
  }
  public deleteLijek = (route: string) => {
    return this.http.delete(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }
  public getApoteka = (route: string) => {
    return this.http.get(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }
  public getProizvodjac = (route: string) => {
    return this.http.get(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }
  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }
  private generateHeaders = () => {
    return {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
  }
}
