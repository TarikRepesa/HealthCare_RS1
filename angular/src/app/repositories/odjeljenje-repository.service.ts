import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {EnvironmentUrlService} from "../shared/services/environment-url.service";
import {AuthService} from "../shared/services/auth.service";
import {Odjeljenje} from "../interfaces/odjeljenje";

@Injectable({
  providedIn: 'root'
})
export class OdjeljenjeRepositoryService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService, private _authService: AuthService) { }
  public getOdjeljenje = (route: string) => {
    return this.http.get(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }
  public createOdjeljenje = (route: string, odjeljenje: any) => {
    return this.http.post<Odjeljenje>(this.createCompleteRoute(route, this.envUrl.urlAddress), odjeljenje, this.generateHeaders());
  }
  public updateOdjeljenje = (route: string, odjeljenje: Odjeljenje) => {
    return this.http.post(this.createCompleteRoute(route, this.envUrl.urlAddress), odjeljenje, this.generateHeaders());
  }
  public deleteOdjeljenje = (route: string) => {
    return this.http.delete(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }
  public getBolnice = (route: string) => {
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
