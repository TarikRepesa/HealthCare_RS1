import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { EnvironmentUrlService } from "../shared/services/environment-url.service";
import { AuthService } from "../shared/services/auth.service";
import { ZahtjevLijek } from '../interfaces/zahtjev-lijek';

@Injectable({
  providedIn: 'root'
})
export class ZahtjeviLijekovaRepositoryService {
  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService, private _authService: AuthService) { }
  
  public getZahtjeviLijekova = (route: string) => {
    return this.http.get(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }
  public createZahtjev = (route: string, zahtjev: any) => {
    return this.http.post<ZahtjevLijek>(this.createCompleteRoute(route, this.envUrl.urlAddress), zahtjev, this.generateHeaders());
  }
  public deleteZahtjev = (route: string) => {
    return this.http.delete(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }
  public odobriZahtjev = (route: string) => {
    return this.http.patch(this.createCompleteRoute(route, this.envUrl.urlAddress), {});
  }
  public odbijZahtjev = (route: string) => {
    return this.http.patch(this.createCompleteRoute(route, this.envUrl.urlAddress), {});
  }
  public getApoteka = (route: string) => {
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
