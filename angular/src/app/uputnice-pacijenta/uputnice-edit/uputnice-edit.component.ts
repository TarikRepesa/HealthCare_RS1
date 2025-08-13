import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgToastService } from 'ng-angular-popup';
import { ToastService } from 'src/app/ngToastService/toast.service';
import { UputniceRepositoryService } from 'src/app/repositories/uputnice-repository.service';
import { TranslateService } from '@ngx-translate/core';
import { Odjeljenje } from 'src/app/interfaces/odjeljenje';
import { Odsjek } from 'src/app/interfaces/odsjek';
import { SifraBolesti } from 'src/app/interfaces/sifra-bolesti';
import { OdjeljenjeRepositoryService } from 'src/app/repositories/odjeljenje-repository.service';
import { OdsjekRepositoryService } from 'src/app/repositories/odsjek-repository.service';
import { SifraBolestiRepositoryService } from 'src/app/repositories/sifra-bolesti-repository.service';


@Component({
  selector: 'app-uputnice-edit',
  templateUrl: './uputnice-edit.component.html',
  styleUrl: './uputnice-edit.component.css'
})
export class UputniceEditComponent implements OnInit {
  @Input()
  editUputnica: any;

  @Input()
  uputnicaId: number;

  @Output()
  open = new EventEmitter<boolean>();

  showEditUputnica: boolean = false;

  odjeljenja: Odjeljenje[];
  odsjeci: Odsjek[];
  sifreBolesti: SifraBolesti[];

  show: boolean = true;
  editMessage="Uputnica uspjesno editovana!";

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
    private toast: ToastService,
    private translate: TranslateService
  ) { }


  ngOnInit(): void {
    this.getOdjeljenja();
    this.getOdsjeci(this.editUputnica.odjeljenjeId);
    this.getSifreBolesti();
    this.translateMessage();
  }

  private translateMessage() {
    this.translate.get('EDIT_UPUTNICA').subscribe((translatedText: string) => {
      this.editMessage = translatedText;
    });
  }

  Close() {
    this.show = !this.show;
    this.open.emit(this.show);
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
    this.editUputnica.odsjekId = null;
    this.getOdsjeci(odjeljenjeId);
  }
  
  SaveChanges() {

    let editUputnica = {
      ljekarId: this.editUputnica.ljekarId,
      odjeljenjeId: this.editUputnica.odjeljenjeId,
      odsjekId: this.editUputnica.odsjekId,
      dijagnoza: this.editUputnica.dijagnoza,
      primjedba: this.editUputnica.primjedba,
      sifreBolestiId: this.editUputnica.sifreBolestiId
    }

    this.repository.updateUputnica(`Uputnica/Edit/${this.uputnicaId}`, editUputnica)
      .subscribe(() => {
        this.toast.showSuccess(this.editMessage);
        this.Close();
        setTimeout(() => {
          window.location.reload();
        }, 2000)
      })
  }

  
  form_validation_messages = {
    'Odjeljenje': [
      { type: 'required', message: 'Odjeljenje.required' }
    ],
    'Odsjek': [
      { type: 'required', message: 'Odsjek.required' }
    ],
    'Dijagnoza': [
      { type: 'minlength', message: 'Dijagnoza.minlength' },
      { type: 'maxlength', message: 'Dijagnoza.maxlength' },
      { type: 'required', message: 'Dijagnoza.required' }
    ],
    'Primjedba': [
      { type: 'maxlength', message: 'Primjedba.maxlength' },
    ],
    'SifreBolesti': [
      { type: 'required', message: 'SifreBolesti.required' }
    ]
  }

}
