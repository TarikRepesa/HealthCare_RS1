import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class ReceptiRepositoryService {

  constructor(private httpKlijent: HttpClient, private envUrl: EnvironmentUrlService) { }

  public getRecepti = (route: string) => {
    return this.httpKlijent.get(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  public getLjekari = (route: string) => {
    return this.httpKlijent.get(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  public getReceptById = (route: string) => {
    return this.httpKlijent.get(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  public getReceptByPacijentId = (route: string) => {
    return this.httpKlijent.get(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  public updateRecept = (route: string, editRecept: any) => {
    return this.httpKlijent.put(this.createCompleteRoute(route, this.envUrl.urlAddress), editRecept);
  }

  public createRecept = (route: string, newRecept: any) => {
    return this.httpKlijent.post(this.createCompleteRoute(route, this.envUrl.urlAddress), newRecept);
  }

  public deleteRecept = (route: string) => {
    return this.httpKlijent.delete(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }
}
