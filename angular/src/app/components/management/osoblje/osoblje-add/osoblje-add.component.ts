import {Component, Input} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {OsobljeRepositoryService} from "../../../../repositories/osoblje-repository.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import { Uloga } from 'src/app/interfaces/uloga';
import {LijekoviRepositoryService} from "src/app/repositories/lijekovi-repository.service";
import { ToastService } from 'src/app/ngToastService/toast.service';
import { TranslateService } from '@ngx-translate/core';


@Component({
  selector: 'app-osoblje-add',
  templateUrl: './osoblje-add.component.html',
  styleUrls: ['./osoblje-add.component.css']
})
export class OsobljeAddComponent {
  @Input() addOsoblje:any;
  @Input() OdjeljenjeId:any;
  odjeljenja: any;
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
    Uloga: new FormControl('', Validators.compose([
      Validators.required
    ])),
    Specifikacija: new FormControl(''),
    Specijalizacija: new FormControl(''),
    Kvalifikacija: new FormControl(''),
    Sifra: new FormControl(''),
    ApotekaId: new FormControl(''),
    Enable2FA: new FormControl(false),
  })

  uloge: Array<Uloga>;
  apoteke:any;

  selectedImage: string | ArrayBuffer;
  selectedFile: File;

  constructor(private _http: HttpClient, private repository: OsobljeRepositoryService, private toast: ToastService, private translate: TranslateService) { }
  ngOnInit(): void {
    this.uloge = [
      {naziv: "Ljekar"},
      {naziv: "Tehnicar"},
      {naziv: "Farmaceut"},
      {naziv: "Asistent"}
    ];
    this.getApoteka();
  }

  getApoteka() {
    this.repository.getApoteka('Lijek/GetApoteka')
      .subscribe((result: any) => {
        this.apoteke = result;
      });
  }

  onAddOsoblje () {
    let newOsoblje = {
      Ime: this.addOsoblje.Ime,
      Prezime: this.addOsoblje.prezime,
      Email: this.addOsoblje.email,
      BrojTelefona: this.addOsoblje.brojTelefona,
      GodineIskustva: this.addOsoblje.godineIskustva,
      OdjeljenjeId: this.OdjeljenjeId,
      slika: this.selectedImage,
      Enable2FA: this.addOsoblje.enable2FA,
      Uloga: this.addOsoblje.uloga,
      Specifikacija: this.addOsoblje.specifikacija,
      Specijalizacija: this.addOsoblje.specijalizacija,
      Kvalifikacija: this.addOsoblje.kvalifikacija,
      Sifra: this.addOsoblje.sifra,
      ApotekaId: this.addOsoblje.apotekaId,
    }
    const updateUrl: string = `Osoblje/Add`;
    this.repository.createOsoblje(updateUrl, newOsoblje).subscribe(() =>{
      this.ocistiPodatke();
      setTimeout(() => {
        window.location.reload();
      }, 500)
    });
    this.toast.showSuccess("Novi korisnik uspjesno dodan!");
  }
  ocistiPodatke() {
    this.addOsoblje.prikaz = false;
    this.selectedFile = null;
    this.selectedImage = null
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
    'Uloga': [
      { type: 'required', message: 'Odabir uloge je obavezan!' },
    ],
    'Specifikacija': [
      { type: 'required', message: 'Unos specifikacije je obavezan!' },
    ],
    'Specijalizacija': [
      { type: 'required', message: 'Unos specijalizacije je obavezan!' },
    ],
    'Kvalifikacija': [
      { type: 'required', message: 'Unos kvalifikacije je obavezan!' },
    ],
    'Sifra': [
      { type: 'required', message: 'Unos sifre je obavezan!' },
    ],
    'ApotekaId': [
      { type: 'required', message: 'Odabir apoteke je obavezan!' },
    ],
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


}
