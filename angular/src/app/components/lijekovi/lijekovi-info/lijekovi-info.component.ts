import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';

@Component({
  selector: 'app-lijekovi-info',
  templateUrl: './lijekovi-info.component.html',
  styleUrls: ['./lijekovi-info.component.css']
})
export class LijekoviInfoComponent implements OnInit {
  @Input() lijekOpis:any;
  @Output()
  Open_Close_InfoModal = new EventEmitter<boolean>();
  show: boolean = true;
  ngOnInit(): void {

  }

  Close() {
    this.show = !this.show;
    this.Open_Close_InfoModal.emit(this.show);
  }
}
