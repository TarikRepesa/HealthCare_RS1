import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class NalaziRepositoryService {

  constructor(private httpKlijent: HttpClient, private envUrl: EnvironmentUrlService) { }

  public getNalazi = (route: string) => {
    return this.httpKlijent.get(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  public getLjekari = (route: string) => {
    return this.httpKlijent.get(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  public getNalazById = (route: string) => {
    return this.httpKlijent.get(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  public getNalazByPacijentId = (route: string) => {
    return this.httpKlijent.get(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  public updateNalaz = (route: string, editNalaz: any) => {
    return this.httpKlijent.put(this.createCompleteRoute(route, this.envUrl.urlAddress), editNalaz);
  }

  public createNalaz = (route: string, newNalaz: any) => {
    return this.httpKlijent.post(this.createCompleteRoute(route, this.envUrl.urlAddress), newNalaz);
  }

  public deleteNalaz = (route: string) => {
    return this.httpKlijent.delete(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }
}
