import { Component, OnInit } from '@angular/core';
import { LjekariRepositoryService } from 'src/app/repositories/ljekari-repository.service';

@Component({
  selector: 'app-ljekari',
  templateUrl: './ljekari.component.html',
  styleUrls: ['./ljekari.component.css']
})
export class LjekariComponent implements OnInit {

  ljekari: any;
  employee: any;
  showDetails: boolean = false;
  filter: string = "";

  OpenDetails($event: any) {
    this.showDetails = $event;
  }

  constructor(private repository: LjekariRepositoryService) { }

  ngOnInit() {
    this.getLjekari();
  }

  getLjekari() {
    this.repository.getLjekari('Ljekar/GetAll')
      .subscribe((x: any) => {
        this.ljekari = x;
      });
  }

  filterData() {
    if(this.ljekari == null){
      return [];
    }

    return this.ljekari.filter((x: any) => (x.ime + " " + x.prezime).toLowerCase().startsWith(this.filter.toLowerCase()) 
    || (x.prezime + " " + x.ime).toLowerCase().startsWith(this.filter.toLowerCase()));
  }

  getEmployee(id: number) {
    this.repository.getLjekarById(`Ljekar/Get/?id=${id}`)
      .subscribe((result: any) => {
        this.employee = result;
      });
  }

  get_slika_base64_DB(x: any){
    return "data:image/jpg|png;base64," + x.slika;
  }
}
