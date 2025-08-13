import {Component, OnInit, Input} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import { ZahtjeviLijekovaRepositoryService } from 'src/app/repositories/zahtjevi-lijekova-repository.service';
import { ToastService } from 'src/app/ngToastService/toast.service';

@Component({
  selector: 'app-zahtjevi-lijekova-add',
  templateUrl: './zahtjevi-lijekova-add.component.html',
  styleUrls: ['./zahtjevi-lijekova-add.component.css']
})
export class ZahtjeviLijekovaAddComponent implements OnInit{

  @Input() addZahtjev: any;

  apoteke: any;
  apotekaChosen: any;
  form = new FormGroup({
    Naziv: new FormControl('', Validators.compose([
      Validators.maxLength(25),
      Validators.minLength(2),
      Validators.pattern('^[A-Z][a-z_\\-]+$'),
      Validators.required
    ])),
    Kolicina: new FormControl('', Validators.compose([
      Validators.pattern('^[01]?[0-9][0-9]?$'),
      Validators.required
    ])),
    Apoteka: new FormControl('', Validators.required),
  })
  constructor(private _http: HttpClient, private repository: ZahtjeviLijekovaRepositoryService, private toast: ToastService,) { }

  ngOnInit(): void {
    this.getApoteka();
  }

  onAddLijek() {
    let newZahtjev = {
      Naziv: this.addZahtjev.naziv,
      Kolicina: this.addZahtjev.kolicina,
      ApotekaId: this.apotekaChosen,
    }
    const updateUri: string = `ZahtjevLijek/Add`;
    this.repository.createZahtjev(updateUri, newZahtjev).subscribe(() =>{
      this.addZahtjev = null;
      setTimeout(() => {
        window.location.reload();
      }, 500)
    });
    this.toast.showSuccess("Zahtjev uspjesno poslan!");  
  }
  getApoteka() {
    this.repository.getApoteka('ZahtjevLijek/GetApoteka')
      .subscribe((result: any) => {
        this.apoteke = result;
      });
  }
  form_validation_messages = {
    'Naziv': [
      { type: 'minlength', message: 'Naziv mora biti duzi od 2 slova!' },
      { type: 'maxlength', message: 'Naziv ne smije biti duzi od 25 slova!' },
      { type: 'required', message: 'Unos naziva je obavezan!' },
      { type: 'pattern', message: 'Unesite ispravan naziv!' }
    ],
    'Kolicina': [
      { type: 'required', message: 'Unos kolicine je obavezan!' },
      { type: 'pattern', message: 'Unesite ispravnu vrijednost kolicine 1-200!' }
    ],
    'Apoteka': [
      { type: 'required', message: 'Odabir apoteke je obavezan!' },
      { type: 'pattern', message: 'Odaberite ispravnu apoteku!' }
    ],
  }
}
