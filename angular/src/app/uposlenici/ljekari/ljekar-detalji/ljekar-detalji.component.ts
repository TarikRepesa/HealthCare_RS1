import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { LjekariRepositoryService } from 'src/app/repositories/ljekari-repository.service';

@Component({
  selector: 'app-ljekar-detalji',
  templateUrl: './ljekar-detalji.component.html',
  styleUrls: ['./ljekar-detalji.component.css']
})
export class LjekarDetaljiComponent implements OnInit {

  @Input()
  employee: any;

  @Output()
  open = new EventEmitter<boolean>();

  show: boolean = true;

  constructor(private repository: LjekariRepositoryService) { }

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
