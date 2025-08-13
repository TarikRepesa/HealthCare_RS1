import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { NgToastService } from 'ng-angular-popup';
import { ToastService } from 'src/app/ngToastService/toast.service';
import { NalaziRepositoryService } from 'src/app/repositories/nalazi-repository.service';
import { TerminiRepositoryService } from 'src/app/repositories/termini-repository.service';

@Component({
  selector: 'app-nalazi-add',
  templateUrl: './nalazi-add.component.html',
  styleUrls: ['./nalazi-add.component.css']
})
export class NalazAddComponent implements OnInit {
  @Input()
  pacijentId: any;

  @Output()
  open = new EventEmitter<boolean>();

  vrsta: any;
  prioritet: any;
  ljekarId: any;
  ljekari: any;

  show: boolean = true;
  addMessage: any;

  form = new FormGroup({
    Vrsta: new FormControl('', Validators.compose([
      Validators.minLength(2),
      Validators.maxLength(50),
      Validators.required
    ])),
    Prioritet: new FormControl('', Validators.compose([
      Validators.minLength(2),
      Validators.maxLength(50),
      Validators.required
    ])),
    Ljekar: new FormControl('', Validators.compose([
      Validators.required
    ])),
  });

  constructor(private repository: NalaziRepositoryService, private toast: ToastService, private pipe: DatePipe, private translate: TranslateService) { }

  ngOnInit() {
    this.getLjekari();
    this.translateMessage();
  }

  private translateMessage() {
    this.translate.get('ADD_NALAZ').subscribe((translatedText: string) => {
      this.addMessage = translatedText;
    });
  }

  Close() {
    this.show = !this.show;
    this.open.emit(this.show);
  }

  getLjekari() {
    this.repository.getLjekari('Nalaz/GetLjekarByNameSurname')
      .subscribe((result: any) => {
        this.ljekari = result;
        this.ljekarId = result[0].id;
      });
  }

  SaveChanges() {
    let createNalaz = {
      vrsta: this.vrsta,
      prioritet: this.prioritet,
      ljekarId: this.ljekarId
    }

    this.repository.createNalaz(`Nalaz/Add/${this.pacijentId}`, createNalaz)
      .subscribe(() => {
        this.toast.showSuccess(this.addMessage);
        this.Close();
        setTimeout(() => {
          window.location.reload();
        }, 3000);
      });
  }

  form_validation_messages = {
    'Vrsta': [
      { type: 'minlength', message: 'Vrsta.minlength' },
      { type: 'maxlength', message: 'Vrsta.maxlength' },
      { type: 'required', message: 'Vrsta.required' }
    ],
    'Prioritet': [
      { type: 'minlength', message: 'Prioritet.minlength' },
      { type: 'maxlength', message: 'Prioritet.maxlength' },
      { type: 'required', message: 'Prioritet.required' }
    ],
    'Ljekar': [
      { type: 'required', message: 'Ljekar.required' }
    ]
  }

}
