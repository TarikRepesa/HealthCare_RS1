import { Component, OnInit } from '@angular/core';
import { FarmaceutiRepositoryService } from 'src/app/repositories/farmaceuti-repository.service';

@Component({
  selector: 'app-farmaceuti',
  templateUrl: './farmaceuti.component.html',
  styleUrls: ['./farmaceuti.component.css']
})
export class FarmaceutiComponent implements OnInit {

  farmaceuti: any;
  employee: any;
  showDetails: boolean = false;
  filter: string = "";

  OpenDetails($event: any) {
    this.showDetails = $event;
  }

  constructor(private repository: FarmaceutiRepositoryService) { }

  ngOnInit() {
    this.getFarmaceuti();
  }

  getFarmaceuti() {
    this.repository.getFarmaceuti('Farmaceut/GetAll')
      .subscribe((x: any) => {
        this.farmaceuti = x;
      });
  }

  getEmployee(id: number) {
    this.repository.getFarmaceutById(`Farmaceut/GetById/${id}`)
      .subscribe((result: any) => {
        this.employee = result;
      });
  }

  filterData() {
    if (this.farmaceuti == null) {
      return [];
    }

    return this.farmaceuti.filter((x: any) => (x.ime + " " + x.prezime).toLowerCase().startsWith(this.filter.toLowerCase())
      || (x.prezime + " " + x.ime).toLowerCase().startsWith(this.filter.toLowerCase()));
  }

  get_slika_base64_DB(x: any) {
    return "data:image/jpg|png;base64," + x.slika;
  }
}
