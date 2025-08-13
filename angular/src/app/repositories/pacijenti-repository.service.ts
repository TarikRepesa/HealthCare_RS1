import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class PacijentiRepositoryService {

  constructor(private httpKlijent: HttpClient, private envUrl: EnvironmentUrlService) { }

  public getPacijenti = (route: string) => {
    return this.httpKlijent.get(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  public deletePacijent = (route: string) => {
    return this.httpKlijent.delete(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  public editPacijent = (route: string) => {
    return this.httpKlijent.get(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  public updatePacijent = (route: string, pacijent: any) => {
    return this.httpKlijent.put(this.createCompleteRoute(route, this.envUrl.urlAddress), pacijent);
  }

  public createPacijent = (route: string, newPacijent: any) => {
    return this.httpKlijent.post(this.createCompleteRoute(route, this.envUrl.urlAddress), newPacijent);
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }

}
