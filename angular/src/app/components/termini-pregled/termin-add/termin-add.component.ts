import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { er } from '@fullcalendar/core/internal-common';
import { TranslateService } from '@ngx-translate/core';
import { NgToastService } from 'ng-angular-popup';
import { PagedList } from 'src/app/interfaces/PagedList';
import { ToastService } from 'src/app/ngToastService/toast.service';
import { PacijentiRepositoryService } from 'src/app/repositories/pacijenti-repository.service';
import { TerminiRepositoryService } from 'src/app/repositories/termini-repository.service';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-termin-add',
  templateUrl: './termin-add.component.html',
  styleUrls: ['./termin-add.component.css']
})
export class TerminAddComponent implements OnInit {


  @Output()
  Open_Close_AddModal = new EventEmitter<boolean>();

  @Input()
  datumPosjete: any;

  @Input()
  vrijemePosjeteOd: any;

  vrijemePosjeteDo: any;
  vrsta_pregleda: string;
  prioritet: string;
  pacijentId: any;
  ljekarId: any;
  ambulantaId: number;

  ljekari: any;
  ambulante: any;
  pacijenti?: PagedList | null;
  defaultLjekar: any;
  defaultAmbulanta: any;

  filterByNameSurname: string = "";
  filterByMjestoRodenja: string = "";

  currentPage: number = 1;
  pageSize: number = 10;
  tableSize: number[] = [5, 10, 15, 20];

  selected: any;
  selectedRow: number;

  show: boolean = true;

  addMessage: any;
  errorMessage: any;

  isUserPacijent: boolean = false;

  public pageNumbersArray(): number[] {
    let result = [];

    for (let i = 0; i < this.totalPages(); i++)
      result.push(i + 1);
    return result;
  }

  private totalPages() {
    if (this.pacijenti != null)
      return this.pacijenti!.totalPages;

    return 1;
  }

  form = new FormGroup({
    DatumPosjete: new FormControl('', Validators.compose([
      Validators.required
    ])),
    VrijemePosjeteOd: new FormControl('', Validators.compose([
      Validators.required
    ])),
    VrijemePosjeteDo: new FormControl('', Validators.compose([
      Validators.required
    ])),
    VrstaPregleda: new FormControl('', Validators.compose([
      Validators.minLength(2),
      Validators.maxLength(100),
      Validators.required
    ])),
    Prioritet: new FormControl('', Validators.compose([
      Validators.minLength(2),
      Validators.maxLength(100),
      Validators.required
    ])),
    Ljekar: new FormControl('', Validators.compose([
      Validators.required
    ])),
    Ambulanta: new FormControl('', Validators.compose([
      Validators.required
    ])),
  });

  constructor(private repositoryTermin: TerminiRepositoryService, private repositoryPacijent: PacijentiRepositoryService, private toastService: ToastService, private datePipe: DatePipe,
    private translate: TranslateService, private _authService: AuthService) {
  }

  ngOnInit() {
    this.isPacijent();
    this.getLjekari();
    this.getAmbulante();
    this.translateMessage();
  }

  private translateMessage() {
    this.translate.get('TERMIN_ADD').subscribe((translatedText: string) => {
      this.addMessage = translatedText;
    });

    this.translate.get('TERMIN_ERROR').subscribe((translatedText: string) => {
      this.errorMessage = translatedText;
    });
  }

  public isPacijent = () => {
    return this._authService.checkIfUserIsPacijent()
      .then(res => {
        this.isUserPacijent = res;
      })
  }

  Close() {
    this.show = !this.show;
    this.Open_Close_AddModal.emit(this.show);
  }

  getLjekari() {
    this.repositoryTermin.getLjekari('Termin/GetLjekarByNameSurname')
      .subscribe((result: any) => {
        this.ljekari = result;
        this.defaultLjekar = result[0].id;
      });
  }

  getAmbulante() {
    this.repositoryTermin.getAmbulante('Termin/GetAmbulanteByNaziv')
      .subscribe((result: any) => {
        this.ambulante = result;
        this.defaultAmbulanta = result[0].id;
      });
  }

  getPacijenti() {
    this.repositoryPacijent.getPacijenti(`Pacijent/GetAll?ime_prezime=${this.filterByNameSurname}&mjesto_rodenja=${this.filterByMjestoRodenja}&pageNumber=${this.currentPage}`)
      .subscribe((result: any) => {
        this.pacijenti = result;
      });
  }

  selectItem(item: any): void {
    this.selectedRow = item.id;
  }

  goToPage(p: number) {
    this.currentPage = p;
    this.getPacijenti();
  }

  goToPrev() {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.getPacijenti();
    }
  }

  goToNext() {
    if (this.currentPage < this.totalPages()) {
      this.currentPage++
      this.getPacijenti();
    }
  }

  Search() {
    this.currentPage = 1;
    this.getPacijenti();
  }

  resetFilter() {
    this.filterByMjestoRodenja = "";
    this.filterByNameSurname = "";
    this.selectedRow = null;

    this.getPacijenti();
  }

  SaveChanges() {
    let newTermin = {
      vrijemeOd: new Date(this.datumPosjete + ' ' + this.vrijemePosjeteOd + ' UTC').toISOString(),
      vrijemeDo: new Date(this.datumPosjete + ' ' + this.vrijemePosjeteDo + ' UTC').toISOString(),
      vrsta: this.vrsta_pregleda,
      prioritet: this.prioritet,
      ljekarId: this.defaultLjekar,
      ambulantaId: this.defaultAmbulanta
    };

    this.repositoryTermin.createTermin('Termin/Add/', newTermin)
      .subscribe(() => {
        this.toastService.showSuccess(this.addMessage);

        setTimeout(() => {
          window.location.reload();
        }, 3000);

      }, error => {
        this.toastService.showError(this.errorMessage);
      });
  }

  form_validation_messages = {
    'DatumPosjete': [
      { type: 'required', message: 'DatumPosjete.required' }
    ],
    'VrijemePosjeteOd': [
      { type: 'required', message: 'VrijemePosjeteOd.required' }
    ],
    'VrijemePosjeteDo': [
      { type: 'required', message: 'VrijemePosjeteDo.required' }
    ],
    'VrstaPregleda': [
      { type: 'minlength', message: 'VrstaPregleda.minlength' },
      { type: 'maxlength', message: 'VrstaPregleda.maxlength' },
      { type: 'required', message: 'VrstaPregleda.required' }
    ],
    'Prioritet': [
      { type: 'minlength', message: 'Prioritet.minlength' },
      { type: 'maxlength', message: 'Prioritet.maxlength' },
      { type: 'required', message: 'Prioritet.required' }
    ],
    'Ljekar': [
      { type: 'required', message: 'Ljekar.required' }
    ],
    'Ambulanta': [
      { type: 'required', message: 'Ambulanta.required' }
    ]
  }
}
