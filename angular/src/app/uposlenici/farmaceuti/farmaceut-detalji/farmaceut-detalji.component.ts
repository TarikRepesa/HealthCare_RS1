import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FarmaceutiRepositoryService } from 'src/app/repositories/farmaceuti-repository.service';

@Component({
  selector: 'app-farmaceut-detalji',
  templateUrl: './farmaceut-detalji.component.html',
  styleUrls: ['./farmaceut-detalji.component.css']
})
export class FarmaceutDetaljiComponent implements OnInit {

  @Input()
  employee: any;

  @Output()
  open = new EventEmitter<boolean>();

  show: boolean = true;

  constructor(private repository: FarmaceutiRepositoryService) { }

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
