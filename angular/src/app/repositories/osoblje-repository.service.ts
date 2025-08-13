import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {EnvironmentUrlService} from "../shared/services/environment-url.service";
import {AuthService} from "../shared/services/auth.service";
import {Osoblje} from "../interfaces/osoblje";

@Injectable({
  providedIn: 'root'
})
export class OsobljeRepositoryService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService, private _authService: AuthService) { }
  public getOsoblje = (route: string) => {
    return this.http.get(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }
  public createOsoblje = (route: string, osoblje: any) => {
    return this.http.post<Osoblje>(this.createCompleteRoute(route, this.envUrl.urlAddress), osoblje, this.generateHeaders());
  }
  public updateOsoblje = (route: string, osoblje: Osoblje) => {
    return this.http.post(this.createCompleteRoute(route, this.envUrl.urlAddress), osoblje, this.generateHeaders());
  }
  public deleteOsoblje = (route: string) => {
    return this.http.delete(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }
  public getOdjeljenja = (route: string) => {
    return this.http.get(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }
  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }
  public getApoteka = (route: string) => {
    return this.http.get(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }
  private generateHeaders = () => {
    return {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
  }
}
