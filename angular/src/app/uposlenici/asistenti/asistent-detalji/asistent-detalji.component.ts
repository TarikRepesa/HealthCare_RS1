import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AsistentiRepositoryService } from 'src/app/repositories/asistenti-repository.service';

@Component({
  selector: 'app-asistent-detalji',
  templateUrl: './asistent-detalji.component.html',
  styleUrls: ['./asistent-detalji.component.css']
})
export class AsistentDetaljiComponent implements OnInit {

  @Input()
  employee: any;

  @Output()
  open = new EventEmitter<boolean>();

  show: boolean = true;

  constructor(private repository: AsistentiRepositoryService) { }

  ngOnInit() {
  }

  Close() {
    this.show = !this.show;
    this.open.emit(this.show);
  }

  get_slika_base64_DB(x: any){
    return "data:image/jpg|png;base64," + x.slika_korisnika;
  }
}
