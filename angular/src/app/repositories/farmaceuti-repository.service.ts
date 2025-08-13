import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class FarmaceutiRepositoryService {

  constructor(private httpKlijent: HttpClient, private envUrl: EnvironmentUrlService) { }

  public getFarmaceuti = (route: string) => {
    return this.httpKlijent.get(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  public getFarmaceutById = (route: string) => {
    return this.httpKlijent.get(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }

}
