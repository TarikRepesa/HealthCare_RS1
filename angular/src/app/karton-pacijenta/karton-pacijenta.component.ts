import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';

@Component({
  selector: 'app-karton-pacijenta',
  templateUrl: './karton-pacijenta.component.html',
  styleUrls: ['./karton-pacijenta.component.css']
})
export class KartonPacijentaComponent {

  id: any;
  kartonPacijenta: any;

  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute, private url: EnvironmentUrlService) {

  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = params['id'];
      this.loadKarton();
    });
  }

  loadKarton() {
    //const url: string = '/Karton/GetById/' + this.id;

    this.httpKlijent.get(this.url.urlAddress + '/Karton/GetById/' + this.id)
      .subscribe((x: any) => {
        this.kartonPacijenta = x;
      });
  }

  get_slika_base64_DB(x: any) {
    return "data:image/jpg|png;base64," + x.slika_korisnika;
  }
}
