import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { an, ay } from '@fullcalendar/core/internal-common';
import { TranslateService } from '@ngx-translate/core';
import { NgToastService } from 'ng-angular-popup';
import { ToastService } from 'src/app/ngToastService/toast.service';
import { ReceptiRepositoryService } from 'src/app/repositories/recepti-repository.service';
import { TerminiRepositoryService } from 'src/app/repositories/termini-repository.service';

@Component({
  selector: 'app-recept-add',
  templateUrl: './recept-add.component.html',
  styleUrls: ['./recept-add.component.css']
})
export class ReceptAddComponent implements OnInit {
  @Input()
  pacijentId: any;

  @Output()
  open = new EventEmitter<boolean>();

  datumIzdavanja: any;
  vrijemeIzdavanja: any;
  doza: any;
  sifraBolesti: any;
  napomena: any;
  ljekarId: any;
  ljekari: any;

  show: boolean = true;
  addMessage: any;

  form = new FormGroup({
    DatumIzdavanja: new FormControl('', Validators.compose([
      Validators.required
    ])),
    VrijemeIzdavanja: new FormControl('', Validators.compose([
      Validators.required
    ])),
    Doza: new FormControl('', Validators.compose([
      Validators.minLength(2),
      Validators.maxLength(10),
      Validators.required
    ])),
    SifraBolesti: new FormControl('', Validators.compose([
      Validators.pattern('^[A-Z]{1}[0-9]{2}\\s+[A-Z]{1}[0-9]{2}$'),
      Validators.required
    ])),
    Ljekar: new FormControl('', Validators.compose([
      Validators.required
    ])),
    Napomena: new FormControl('', Validators.compose([
      Validators.minLength(2),
      Validators.maxLength(500),
      Validators.required
    ])),
  });

  constructor(private repository: ReceptiRepositoryService, private toast: ToastService, private pipe: DatePipe, private translate: TranslateService) { }

  ngOnInit() {
    this.getLjekari();
    this.translateMessage();

    const date = new Date();
    this.datumIzdavanja = this.pipe.transform(date, 'yyyy-MM-dd');
    this.vrijemeIzdavanja = this.pipe.transform(date, 'HH:mm');
  }

  private translateMessage() {
    this.translate.get('ADD_RECEPT').subscribe((translatedText: string) => {
      this.addMessage = translatedText;
    });
  }

  Close() {
    this.show = !this.show;
    this.open.emit(this.show);
  }

  getLjekari() {
    this.repository.getLjekari('Recept/GetLjekarByNameSurname')
      .subscribe((result: any) => {
        this.ljekari = result;
        this.ljekarId = result[0].id;
      });
  }

  SaveChanges() {
    let createRecept = {
      datumIzdavanja: new Date(this.datumIzdavanja + ' ' + this.vrijemeIzdavanja + ' UTC').toISOString(),
      doza: this.doza,
      napomena: this.napomena,
      sifraBolesti: this.sifraBolesti,
      ljekarId: this.ljekarId
    }

    this.repository.createRecept(`Recept/Add/${this.pacijentId}`, createRecept)
      .subscribe(() => {
        this.toast.showInfo(this.addMessage);
        this.Close();
        setTimeout(() => {
          window.location.reload();
        }, 3000);
      });
  }

  form_validation_messages = {
    'DatumIzdavanja': [
      { type: 'required', message: 'DatumIzdavanja.required' }
    ],
    'VrijemeIzdavanja': [
      { type: 'required', message: 'VrijemeIzdavanja.required' }
    ],
    'Doza': [
      { type: 'minlength', message: 'Doza.minlength' },
      { type: 'maxlength', message: 'Doza.maxlength' },
      { type: 'required', message: 'Doza.required' }
    ],
    'SifraBolesti': [
      { type: 'pattern', message: 'SifraBolesti.pattern' },
      { type: 'required', message: 'SifraBolesti.required' }
    ],
    'Ljekar': [
      { type: 'required', message: 'Ljekar.required' }
    ],
    'Napomena': [
      { type: 'minlength', message: 'Napomena.minlength' },
      { type: 'maxlength', message: 'Napomena.maxlength' },
      { type: 'required', message: 'Napomena.required' }
    ]
  }

}
