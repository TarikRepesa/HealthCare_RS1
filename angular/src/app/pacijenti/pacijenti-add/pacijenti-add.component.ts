import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { NgToastService } from 'ng-angular-popup';
import { ToastService } from 'src/app/ngToastService/toast.service';
import { PacijentiRepositoryService } from 'src/app/repositories/pacijenti-repository.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-pacijenti-add',
  templateUrl: './pacijenti-add.component.html',
  styleUrls: ['./pacijenti-add.component.css']
})
export class PacijentiAddComponent implements OnInit {

  @Input()
  ime: string = "";

  @Input()
  prezime: string = "";

  @Input()
  email: string = "";

  @Input()
  brojTelefona: string = "";

  @Input()
  datumRodenja: any;

  @Input()
  mjestoRodenja: string = "";

  @Input()
  jmbg: string = "";

  @Input()
  datumIzdavanja: any;

  @Input()
  dopunskoOsiguranje: string = "";

  @Input()
  srodstvoOsiguranika: string = "";

  @Output()
  otvori = new EventEmitter<boolean>();

  show: boolean = true;

  selectedImage: string | ArrayBuffer;
  selectedFile: File;

  addMessage: any;

  form = new FormGroup({
    Ime: new FormControl('', Validators.compose([
      Validators.minLength(2),
      Validators.pattern('^[A-Z][a-z_\\-]+$'),
      Validators.required
    ])),
    Prezime: new FormControl('', Validators.compose([
      Validators.minLength(2),
      Validators.pattern('^[A-Z][a-z_\\-]+$'),
      Validators.required
    ])),
    Email: new FormControl('', Validators.compose([
      Validators.pattern('^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$'),
      Validators.required
    ])),
    BrojTelefona: new FormControl('', Validators.compose([
      Validators.pattern('^[(]?[0-9]{3,4}[)]?[-\s\/]?[0-9]{3}[-][0-9]{3,6}$'),
      Validators.required
    ])),
    DatumRodenja: new FormControl('', Validators.compose([
      Validators.required
    ])),
    MjestoRodenja: new FormControl('', Validators.compose([
      Validators.minLength(2),
      Validators.pattern('^[A-Z][a-z_\\-]+$'),
      Validators.required
    ])),
    JMBG: new FormControl('', Validators.compose([
      Validators.pattern('^[0-9]{13}$'),
      Validators.required
    ])),
    DatumIzdavanja: new FormControl('', Validators.compose([
      Validators.required
    ])),
    DopunskoOsiguranje: new FormControl('', Validators.compose([
      Validators.maxLength(200),
      Validators.required
    ])),
    SrodstvoOsiguranika: new FormControl('', Validators.compose([
      Validators.maxLength(200),
      Validators.required
    ])),
  });

  constructor(private repository: PacijentiRepositoryService, private toast: ToastService, private translate: TranslateService) { }

  ngOnInit() {
    this.translateMessage();
  }

  Close() {
    this.show = !this.show;
    this.otvori.emit(this.show);
  }

  private translateMessage() {
    this.translate.get('ADD_PACIJENT').subscribe((translatedText: string) => {
      this.addMessage = translatedText;
    });
  }

  onFileSelected(event: any): void {
    this.selectedFile = event.target.files[0];

    if (this.selectedFile) {
      this.readImage();
    }
  }

  readImage(): void {
    const fileReader = new FileReader();
    fileReader.onload = (e) => {
      this.selectedImage = e.target.result;
    };
    fileReader.readAsDataURL(this.selectedFile);
  }

  SaveChanges() {
    let newPacijent = {
      ime: this.ime,
      prezime: this.prezime,
      email: this.email,
      brojTelefona: this.brojTelefona,
      datumRodenja: this.datumRodenja,
      mjestoRodenja: this.mjestoRodenja,
      jmbg: this.jmbg,
      datumIzdavanja: this.datumIzdavanja,
      dopunskoOsiguranje: this.dopunskoOsiguranje,
      srodstvoOsiguranika: this.srodstvoOsiguranika,
      slika_korisnika: this.selectedImage
    }

    this.repository.createPacijent('Pacijent/Add', newPacijent)
      .subscribe(() => {
        this.toast.showSuccess(this.addMessage);
        this.Close();
        setTimeout(() => {
          window.location.reload();
        }, 2000)
      });
  }

  form_validation_messages = {
    'Ime': [
      { type: 'minlength', message: 'Ime.minlength' },
      { type: 'pattern', message: 'Ime.pattern' },
      { type: 'required', message: 'Ime.required' }
    ],
    'Prezime': [
      { type: 'minlength', message: 'Prezime.minlength' },
      { type: 'pattern', message: 'Prezime.pattern' },
      { type: 'required', message: 'Prezime.required' }
    ],
    'Email': [
      { type: 'pattern', message: 'Email.pattern' },
      { type: 'required', message: 'Email.required' }
    ],
    'BrojTelefona': [
      { type: 'pattern', message: 'BrojTelefona.pattern' },
      { type: 'required', message: 'BrojTelefona.required' }
    ],
    'DatumRodenja': [
      { type: 'required', message: 'DatumRodenja.required' }
    ],
    'MjestoRodenja': [
      { type: 'minlength', message: 'MjestoRodenja.minlength' },
      { type: 'pattern', message: 'MjestoRodenja.pattern' },
      { type: 'required', message: 'MjestoRodenja.required' }
    ],
    'JMBG': [
      { type: 'pattern', message: 'JMBG.pattern' },
      { type: 'required', message: 'JMBG.required' }
    ],
    'DatumIzdavanja': [
      { type: 'required', message: 'DatumIzdavanja.required' }
    ],
    'DopunskoOsiguranje': [
      { type: 'maxLength', message: 'DopunskoOsiguranje.maxLength' },
      { type: 'pattern', message: 'DopunskoOsiguranje.pattern' },
      { type: 'required', message: 'DopunskoOsiguranje.required' }
    ],
    'SrodstvoOsiguranika': [
      { type: 'maxLength', message: 'SrodstvoOsiguranika.maxLength' },
      { type: 'pattern', message: 'SrodstvoOsiguranika.pattern' },
      { type: 'required', message: 'SrodstvoOsiguranika.required' }
    ],
  }
}
