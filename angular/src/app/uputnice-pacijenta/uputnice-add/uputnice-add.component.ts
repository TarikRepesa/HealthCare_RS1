import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgToastService } from 'ng-angular-popup';
import { ToastService } from 'src/app/ngToastService/toast.service';
import { UputniceRepositoryService } from 'src/app/repositories/uputnice-repository.service';
import { TranslateService } from '@ngx-translate/core';
import { OdjeljenjeRepositoryService } from 'src/app/repositories/odjeljenje-repository.service';
import { OdsjekRepositoryService } from 'src/app/repositories/odsjek-repository.service';
import { Odjeljenje } from 'src/app/interfaces/odjeljenje';
import { Odsjek } from 'src/app/interfaces/odsjek';
import { SifraBolesti } from 'src/app/interfaces/sifra-bolesti';
import { SifraBolestiRepositoryService } from 'src/app/repositories/sifra-bolesti-repository.service';


@Component({
  selector: 'app-uputnice-add',
  templateUrl: './uputnice-add.component.html',
  styleUrl: './uputnice-add.component.css'
})
export class UputniceAddComponent implements OnInit {

  @Input()
  pacijentId: string;

  @Output()
  open = new EventEmitter<boolean>();
  
  odjeljenje: string = '';
  odsjek: string = '';
  dijagnoza: string;
  ljekarId: string;
  primjedba: string;
  sifreBolestiOdabrane: number[];

  odjeljenja: Odjeljenje[];
  odsjeci: Odsjek[];
  ljekari: any;
  sifreBolesti: SifraBolesti[];

  show: boolean = true;
  addMessage= "Uputnica uspjesno dodana!";

  form = new FormGroup({
    Odjeljenje: new FormControl('', Validators.compose([
      Validators.required
    ])),
    Odsjek: new FormControl('', Validators.compose([
      Validators.required
    ])),
    Dijagnoza: new FormControl('', Validators.compose([
      Validators.minLength(2),
      Validators.maxLength(50),
      Validators.required
    ])),
    Ljekar: new FormControl('', Validators.compose([
      Validators.required
    ])),
    Primjedba: new FormControl('', Validators.compose([
      Validators.maxLength(100),
    ])),
    SifreBolesti: new FormControl(null, Validators.compose([
      Validators.required
    ])),
  });

  constructor(
    private repository: UputniceRepositoryService,
    private odjeljenjeRepository: OdjeljenjeRepositoryService,
    private odsjekRepository: OdsjekRepositoryService,
    private sifraBolestiRepository: SifraBolestiRepositoryService,
    private pipe: DatePipe,
    private toast: ToastService,
    private translate: TranslateService) { }

  ngOnInit(): void {
    this.getLjekari();
    this.getOdjeljenja();
    this.getSifreBolesti();
    this.translateMessage();
  }

  private translateMessage() {
    this.translate.get('ADD_UPUTNICA').subscribe((translatedText: string) => {
      this.addMessage = translatedText;
    });
  }

  Close() {
    this.show = !this.show;
    this.open.emit(this.show);
  }

  getLjekari() {
    this.repository.getLjekari('Uputnica/GetLjekarByNameSurname')
    .subscribe((result: any) => {
      this.ljekari = result;
      this.ljekarId = result[0].id;
    });
  }

  getOdjeljenja() {
    this.odjeljenjeRepository.getOdjeljenje('Odjeljenje/GetAll')
      .subscribe((result) => {
        this.odjeljenja = result as Odjeljenje[];
      });
  }

  getOdsjeci(odjeljenjeId: number) {
    this.odsjekRepository.getOdsjek(`Odsjek/GetAll?OdjeljenjeId=${odjeljenjeId}`)
      .subscribe((result) => {
        this.odsjeci = result as Odsjek[];
      });
  }

  getSifreBolesti() {
    this.sifraBolestiRepository.getSifraBolesti(`SifraBolesti/GetAll`)
      .subscribe((result) => {
        this.sifreBolesti = result as SifraBolesti[];
      });
  }

  odjeljenjeChanged($event: any) {
    const odjeljenjeId = $event.target.value;
    this.odsjek = '';
    this.getOdsjeci(odjeljenjeId);
  }

  SaveChanges() {
    let createUputnica = {
      odjeljenjeId: this.odjeljenje,
      odsjekId: this.odsjek,
      dijagnoza: this.dijagnoza,
      ljekarId: this.ljekarId,
      primjedba: this.primjedba,
      sifreBolestiId: this.sifreBolestiOdabrane
    }

    this.repository.createUputnica(`Uputnica/Add/${this.pacijentId}`, createUputnica)
      .subscribe(() => {
        this.toast.showSuccess(this.addMessage);
        this.Close();
        setTimeout(() => {
          window.location.reload();
        }, 3000);
      });
  }

  form_validation_messages = {
    'Odjeljenje': [
      { type: 'required', message: 'Odjeljenje.required' }
    ],
    'Odsjek': [
      { type: 'required', message: 'Odjeljenje.required' }
    ],
    'Dijagnoza': [
      { type: 'minlength', message: 'Dijagnoza.minlength' },
      { type: 'maxlength', message: 'Dijagnoza.maxlength' },
      { type: 'required', message: 'Dijagnoza.required' }
    ],
    'Ljekar': [
      { type: 'required', message: 'Ljekar.required' }
    ],
    'SifreBolesti': [
      { type: 'required', message: 'SifreBolesti.required' }
    ]
  }

}
