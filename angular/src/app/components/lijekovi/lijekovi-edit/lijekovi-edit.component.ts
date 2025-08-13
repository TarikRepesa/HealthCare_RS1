import {Component, Input, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {LijekoviRepositoryService} from "../../../repositories/lijekovi-repository.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";


@Component({
  selector: 'app-lijekovi-edit',
  templateUrl: './lijekovi-edit.component.html',
  styleUrls: ['./lijekovi-edit.component.css']
})
export class LijekoviEditComponent implements OnInit {

  @Input() urediLijek:any;

  form = new FormGroup({
    Naziv: new FormControl('', Validators.compose([
      Validators.maxLength(25),
      Validators.minLength(2),
      Validators.pattern('^[A-Z][a-z_\\-]+$'),
      Validators.required
    ])),
    Vrsta: new FormControl('', Validators.compose([
      Validators.maxLength(25),
      Validators.minLength(2),
      Validators.pattern('^[A-Z][a-z_\\-]+$'),
      Validators.required
    ])),
    KolicinaNaStanju: new FormControl('', Validators.compose([
      Validators.pattern('^[01]?[0-9][0-9]?$'),
      Validators.required
    ])),
    Cijena: new FormControl('', Validators.compose([
      Validators.pattern('^[0-9]+.[0-9]{2}$'),
      Validators.required
    ])),
    NacinUpotrebe: new FormControl('', Validators.compose([
      Validators.maxLength(500),
      Validators.minLength(10),
      Validators.required
    ])),
    Nuspojave: new FormControl('', Validators.compose([
      Validators.maxLength(500),
      Validators.minLength(10),
      Validators.required
    ])),
    Upozorenja: new FormControl('', Validators.compose([
      Validators.maxLength(500),
      Validators.minLength(10),
      Validators.required
    ]))
  })
  constructor(private _http: HttpClient, private repository: LijekoviRepositoryService) { }

  ngOnInit(): void {

  }
  onEditLijek () {
    const updateUri: string = `Lijek/Update/${this.urediLijek.id}`;
    this.repository.updateLijek(updateUri, this.urediLijek).subscribe(() =>{
      this.urediLijek.prikaz = false;
      setTimeout(() => {
        window.location.reload();
      }, 500)
    });
  }
  form_validation_messages = {
    'Naziv': [
      { type: 'minlength', message: 'Naziv mora biti duzi od 2 slova!' },
      { type: 'maxlength', message: 'Naziv ne smije biti duzi od 25 slova!' },
      { type: 'required', message: 'Unos naziva je obavezan!' },
      { type: 'pattern', message: 'Unesite ispravan naziv!' }
    ],
    'Vrsta': [
      { type: 'minlength', message: 'Vrsta mora biti duzi od 2 slova!' },
      { type: 'maxlength', message: 'Vrsta ne smije biti duzi od 25 slova!' },
      { type: 'required', message: 'Unos vrste je obavezno!' },
      { type: 'pattern', message: 'Unesite ispravnu vrstu!' }
    ],
    'KolicinaNaStanju': [
      { type: 'required', message: 'Unos kolicine je obavezan!' },
      { type: 'pattern', message: 'Unesite ispravnu vrijednost kolicine 1-200!' }
    ],
    'Cijena': [
      { type: 'required', message: 'Unos cijene je obavezan!' },
      { type: 'pattern', message: 'Unesite ispravnu vrijednost cijene 00,00!' }
    ],
    'NacinUpotrebe': [
      { type: 'minlength', message: 'Nacin upotrebe mora biti duzi od 10 slova!' },
      { type: 'maxlength', message: 'Nacin upotrebe ne smije biti duzi od 500 slova!' },
      { type: 'required', message: 'Unos nacina upotrebe je obavezno!' },
      { type: 'pattern', message: 'Unesite ispravan nacin upotrebe!' }
    ],
    'Nuspojave': [
      { type: 'minlength', message: 'Nuspojava mora biti duzi od 10 slova!' },
      { type: 'maxlength', message: 'Nuspojava ne smije biti duzi od 500 slova!' },
      { type: 'required', message: 'Unos vrste je obavezno!' },
      { type: 'pattern', message: 'Unesite ispravnu nuspojavu!' }
    ],
    'Upozorenja': [
      { type: 'minlength', message: 'Upozorenje mora biti duzi od 10 slova!' },
      { type: 'maxlength', message: 'Upozorenje ne smije biti duzi od 500 slova!' },
      { type: 'required', message: 'Unos upozorenja je obavezno!' },
      { type: 'pattern', message: 'Unesite ispravno upozorenje!' }
    ],
  }
}
