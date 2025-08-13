import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { NgToastService } from 'ng-angular-popup';
import { ToastService } from 'src/app/ngToastService/toast.service';
import { PacijentiRepositoryService } from 'src/app/repositories/pacijenti-repository.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-pacijenti-edit',
  templateUrl: './pacijenti-edit.component.html',
  styleUrls: ['./pacijenti-edit.component.css']
})
export class PacijentiEditComponent implements OnInit {

  @Input()
  ime: string = "";

  @Input()
  prezime: string = "";

  @Input()
  email: string = "";

  @Input()
  brojTelefona: string = "";

  @Input()
  slika: any;

  @Input()
  pacijentId: any;

  @Output()
  otvori = new EventEmitter<boolean>();

  show: boolean = true;

  selectedImage: string | ArrayBuffer;
  selectedFile: File;

  editMessage: any;

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
  });

  constructor(private repository: PacijentiRepositoryService, private toast: ToastService, private translate: TranslateService) { }

  ngOnInit() {
    this.translateMessage();
  }

  private translateMessage() {
    this.translate.get('EDIT_PACIJENT').subscribe((translatedText: string) => {
      this.editMessage = translatedText;
    });
  }

  Close() {
    this.show = !this.show;
    this.otvori.emit(this.show);
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

  get_slika_base64_DB(slika: any) {
    return "data:image/jpg|png;base64," + slika;
  }

  SaveChanges() {
    let editPacijent = {
      pacijentId: this.pacijentId,
      ime: this.ime,
      prezime: this.prezime,
      brojTelefona: this.brojTelefona,
      email: this.email,
      slika_korisnika: this.selectedImage
    }

    this.repository.updatePacijent('Pacijent/Edit/' + this.pacijentId, editPacijent)
      .subscribe(() => {
        this.Close();
        this.toast.showInfo(this.editMessage);
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
    ]
  }

}
