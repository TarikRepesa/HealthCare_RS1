import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { EventContainer } from '@fullcalendar/core/internal';
import { Bolnica } from 'src/app/interfaces/bolnica';

@Component({
  selector: 'app-termini-info',
  templateUrl: './termini-info.component.html',
  styleUrls: ['./termini-info.component.css']
})
export class TerminiInfoComponent implements OnInit {

  @Input()
  termin: any;

  @Output()
  open = new EventEmitter<boolean>();

  show: boolean = true;

  constructor() { }

  ngOnInit() {
  }

  Close() {
    this.show = !this.show;
    this.open.emit(this.show);
  }
}
