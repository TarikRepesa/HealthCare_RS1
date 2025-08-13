import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { TehnicariRepositoryService } from 'src/app/repositories/tehnicari-repository.service';

@Component({
  selector: 'app-tehnicar-detalji',
  templateUrl: './tehnicar-detalji.component.html',
  styleUrls: ['./tehnicar-detalji.component.css']
})
export class TehnicarDetaljiComponent implements OnInit {

  @Input()
  employee: any;

  @Output()
  open = new EventEmitter<boolean>();

  show: boolean = true;
  
  constructor(private repository: TehnicariRepositoryService) { }

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
