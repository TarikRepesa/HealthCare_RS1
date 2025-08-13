import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class UputniceRepositoryService {

  constructor(private httpKlijent: HttpClient, private envUrl: EnvironmentUrlService) { }

  public getById = (route: string) => {
    return this.httpKlijent.get(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  public getByPacijentId = (pacijentId: string) => {
    return this.httpKlijent.get(this.createCompleteRoute('Uputnica/GetByPacijentId/' + pacijentId, this.envUrl.urlAddress));
  }

  public getLjekari = (route: string) => {
    return this.httpKlijent.get(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  public createUputnica = (route: string, newUputnica: any) => {
    return this.httpKlijent.post(this.createCompleteRoute(route, this.envUrl.urlAddress), newUputnica);
  }
  
  public updateUputnica = (route: string, editUputnica: any) => {
    return this.httpKlijent.put(this.createCompleteRoute(route, this.envUrl.urlAddress), editUputnica);
  }

  public deleteUputnica = (route: string) => {
    return this.httpKlijent.delete(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }
}
