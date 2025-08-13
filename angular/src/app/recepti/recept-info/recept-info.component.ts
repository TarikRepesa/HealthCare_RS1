import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-recept-info',
  templateUrl: './recept-info.component.html',
  styleUrls: ['./recept-info.component.css']
})
export class ReceptInfoComponent implements OnInit {

  @Input()
  recept: any;

  @Output()
  open = new EventEmitter<boolean>();

  show: boolean = true;

  constructor() { }

  ngOnInit() {
  }

  Close(){
    this.show = !this.show;
    this.open.emit(this.show);
  }

}
