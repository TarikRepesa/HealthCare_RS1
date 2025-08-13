import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { an } from '@fullcalendar/core/internal-common';

@Component({
  selector: 'app-confirm-dialog',
  templateUrl: './confirm-dialog.component.html',
  styleUrls: ['./confirm-dialog.component.css']
})
export class ConfirmDialogComponent implements OnInit {

  @Input()
  message: string;

  @Input()
  datumPosjete: any;

  @Input()
  vrijemePosjeteOd: any;

  @Output()
  Open_Close_ConfirmModal = new EventEmitter<boolean>();

  show: boolean = true;
  showAddTermin: boolean = false;

  constructor() { }

  ngOnInit() {
  }

  Close() {
    this.show = !this.show;
    this.Open_Close_ConfirmModal.emit(this.show);
  }

  OpenCloseAddModal($event: any) {
    this.showAddTermin = $event;
  }

  Confirm() {
    this.showAddTermin = true;
  }

}
