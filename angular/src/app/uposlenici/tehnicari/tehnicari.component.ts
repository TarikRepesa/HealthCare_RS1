import { Component, OnInit } from '@angular/core';
import { TehnicariRepositoryService } from 'src/app/repositories/tehnicari-repository.service';

@Component({
  selector: 'app-tehnicari',
  templateUrl: './tehnicari.component.html',
  styleUrls: ['./tehnicari.component.css']
})
export class TehnicariComponent implements OnInit {

  tehnicari: any;
  employee: any;
  showDetails: boolean = false;
  filter: string = ""

  OpenDetails($event: any) {
    this.showDetails = $event;
  }

  constructor(private repository: TehnicariRepositoryService) { }

  ngOnInit() {
    this.getTehnicari();
  }

  getTehnicari() {
    this.repository.getTehnicari('Tehnicar/GetAll')
      .subscribe((x: any) => {
        this.tehnicari = x;
      });
  }

  getEmployee(id: number) {
    this.repository.getTehnicarById(`Tehnicar/GetById/${id}`)
      .subscribe((result: any) => {
        this.employee = result;
      });
  }

  filterData() {
    if (this.tehnicari == null) {
      return [];
    }

    return this.tehnicari.filter((x: any) => (x.ime + " " + x.prezime).toLowerCase().startsWith(this.filter.toLowerCase())
      || (x.prezime + " " + x.ime).toLowerCase().startsWith(this.filter.toLowerCase()));
  }

  get_slika_base64_DB(x: any) {
    return "data:image/jpg|png;base64," + x.slika;
  }
}
