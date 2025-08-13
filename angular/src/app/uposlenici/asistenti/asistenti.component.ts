import { Component, OnInit } from '@angular/core';
import { AsistentiRepositoryService } from 'src/app/repositories/asistenti-repository.service';

@Component({
  selector: 'app-asistenti',
  templateUrl: './asistenti.component.html',
  styleUrls: ['./asistenti.component.css']
})
export class AsistentiComponent implements OnInit {

  asistenti: any;
  employee: any;
  showDetails: boolean = false;
  filter: string = "";

  OpenDetails($event: any) {
    this.showDetails = $event;
  }

  constructor(private repository: AsistentiRepositoryService) { }

  ngOnInit() {
    this.getAsistenti();
  }

  getAsistenti() {
    this.repository.getAsistenti('Asistent/GetAll')
      .subscribe((x: any) => {
        this.asistenti = x;
      });
  }

  getEmployee(id: number) {
    this.repository.getAsistentById(`Asistent/GetById/${id}`)
      .subscribe((result: any) => {
        this.employee = result;
      });
  }

  filterData() {
    if(this.asistenti == null){
      return [];
    }

    return this.asistenti.filter((x: any) => (x.ime + " " + x.prezime).toLowerCase().startsWith(this.filter.toLowerCase()) 
    || (x.prezime + " " + x.ime).toLowerCase().startsWith(this.filter.toLowerCase()));
  }

  get_slika_base64_DB(x: any){
    return "data:image/jpg|png;base64," + x.slika;
  }
}
