import {Component, Input} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {OsobljeRepositoryService} from "../../../../repositories/osoblje-repository.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-osoblje-edit',
  templateUrl: './osoblje-edit.component.html',
  styleUrls: ['./osoblje-edit.component.css']
})
export class OsobljeEditComponent {
  @Input() urediOsoblje:any;
  form = new FormGroup({
    Ime: new FormControl('', Validators.compose([
      Validators.maxLength(25),
      Validators.minLength(1),
      Validators.pattern('^[A-Z][a-z_\\-]+$'),
      Validators.required
    ])),
    Prezime: new FormControl('', Validators.compose([
      Validators.maxLength(25),
      Validators.minLength(1),
      Validators.pattern('^[A-Z][a-z_\\-]+$'),
      Validators.required
    ])),
    GodineIskustva: new FormControl('', Validators.compose([
      Validators.pattern('^(?:[1-9]|[1-2][0-9]|30)$'),
      Validators.required
    ])),
    Email: new FormControl('', Validators.compose([
      Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$'),
      Validators.required
    ])),
    BrojTelefona: new FormControl('', Validators.compose([
      Validators.pattern('^[\\+]?[(]?[0-9]{3,4}[)]?[-\\s\/]?[0-9]{3}[-\\s]?[0-9]{3,6}$'),
      Validators.required
    ])),
  })
  constructor(private _http: HttpClient, private repository: OsobljeRepositoryService) { }
  ngOnInit(): void {

  }
  onEditOsoblje () {
    const updateUrl: string = `Osoblje/Update/${this.urediOsoblje.id}`;
    this.repository.updateOsoblje(updateUrl, this.urediOsoblje).subscribe(() =>{
      this.urediOsoblje.prikaz = false;
      setTimeout(() => {
        window.location.reload();
      }, 500)
    });
  }
  form_validation_messages = {
    'Ime': [
      { type: 'minlength', message: 'Ime mora biti duzi od 1 slova!' },
      { type: 'maxlength', message: 'Ime ne smije biti duzi od 25 slova!' },
      { type: 'required', message: 'Unos imena je obavezan!' },
      { type: 'pattern', message: 'Unesite ispravno ime!' }
    ],
    'Prezime': [
      { type: 'minlength', message: 'Prezime mora biti duzi od 1 slova!' },
      { type: 'maxlength', message: 'Prezime ne smije biti duzi od 25 slova!' },
      { type: 'required', message: 'Unos prezime je obavezan!' },
      { type: 'pattern', message: 'Unesite ispravan prezime!' }
    ],
    'GodineIskustva': [
      { type: 'required', message: 'Unos godina iskustva je obavezan!' },
      { type: 'pattern', message: 'Unesite ispravnu vrijednost  iskustva 1-30!' }
    ],
    'Email': [
      { type: 'minlength', message: 'Email mora biti duzi od 5 slova!' },
      { type: 'required', message: 'Unos emaila je obavezno!' },
      { type: 'pattern', message: 'Unesite ispravnu email adresu!' }
    ],
    'BrojTelefona': [
      { type: 'required', message: 'Unos broja telefona je obavezno!' },
      { type: 'pattern', message: 'Unesite ispravan broj telefona!' }
    ],
  }
}
