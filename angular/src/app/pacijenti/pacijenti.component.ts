import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { PacijentiRepositoryService } from '../repositories/pacijenti-repository.service';
import { Pacijent } from '../interfaces/pacijent';
import { NgToastService } from 'ng-angular-popup';
import { DatePipe } from '@angular/common';
import { PagedList } from '../interfaces/PagedList';
import { ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { ToastService } from '../ngToastService/toast.service';

@Component({
  selector: 'app-pacijenti',
  templateUrl: './pacijenti.component.html',
  styleUrls: ['./pacijenti.component.css']
})
export class PacijentiComponent implements OnInit {

  pacijenti?: PagedList | null;
  filterByNameSurname: string = "";
  filterByMjestoRodenja: string = "";
  filterByJMBG: string = "";

  currentPage: number = 1;
  pageSize: number = 10;
  tableSize: number[] = [5, 10, 15, 20];

  ime: string = "";
  prezime: string = "";
  email: string = "";
  brojTelefona: string = "";
  datumRodenja: any;
  mjestoRodenja: string = "";
  jmbg: string = "";
  datumIzdavanja: any;
  dopunskoOsiguranje: string = "";
  srodstvoOsiguranika: string = "";
  slika: any;

  prikaziDodavanjePacijenta: boolean = false;
  prikaziEditPacijenta: boolean = false;

  pacijentId: any;

  deleteMessage: any;

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

  constructor(private repository: PacijentiRepositoryService, private httpKlijent: HttpClient, private toast: ToastService, private datePipe: DatePipe, private translate: TranslateService) { }

  ngOnInit() {
    this.getPacijenti();
    this.translateMessage();
  }

  private translateMessage() {

    this.translate.get('DELETE_PACIJENT').subscribe((translatedText: string) => {
      this.deleteMessage = translatedText;
    });

   
  }

  Open_Add($event: boolean) {
    this.prikaziDodavanjePacijenta = $event;
  }

  Open_Edit($event: boolean) {
    this.prikaziEditPacijenta = $event;
  }

  getPacijenti = () => {
    this.repository.getPacijenti(`Pacijent/GetAll?ime_prezime=${this.filterByNameSurname}&mjesto_rodenja=${this.filterByMjestoRodenja}&jmbg=${this.filterByJMBG}&pageNumber=${this.currentPage}&pageSize=${this.pageSize}`)
      .subscribe((result: any) => {
        this.pacijenti = result;
      });
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

  onTableSizeChange(event: any) {
    console.log(event);
    this.pageSize = event.target.value;
    this.currentPage = 1;
    this.getPacijenti();
  }

  getPodaci() {
    if (this.pacijenti == null)
      return [];

    return this.pacijenti.dataItems.filter((x: any) => (x.ime + " " + x.prezime).toLowerCase().startsWith(this.filterByNameSurname.toLowerCase())
      || (x.prezime + " " + x.ime).toLowerCase().startsWith(this.filterByNameSurname.toLowerCase()));

  }

  get_slika_base64_DB(x: any) {
    return "data:image/jpg|png;base64," + x.slika;
  }

  Search() {
    this.currentPage = 1;
    this.getPacijenti();
  }

  Reset() {
    this.filterByNameSurname = "";
    this.filterByMjestoRodenja = "";
    this.filterByJMBG = "";

    this.currentPage = 1;
    this.getPacijenti();
  }

  noviPacijent() {
    const today = new Date();

    this.ime = "";
    this.prezime = "";
    this.email = "";
    this.brojTelefona = "";
    this.datumRodenja = this.datePipe.transform(today, 'yyyy-MM-dd'),
      this.mjestoRodenja = "";
    this.jmbg = "";
    this.datumIzdavanja = this.datePipe.transform(today, 'yyyy-MM-dd'),
      this.dopunskoOsiguranje = ""
    this.srodstvoOsiguranika = ""
  }

  editPacijent = (pacijentId: any) => {
    this.repository.editPacijent(`Pacijent/GetById/${pacijentId}`)
      .subscribe((result: any) => {
        this.ime = result.ime;
        this.prezime = result.prezime;
        this.email = result.email;
        this.brojTelefona = result.brojTelefona;
        this.slika = result.slika;
      });
  }

  deletePacijent = (id: any) => {
    this.repository.deletePacijent(`Pacijent/Delete/${id}`)
      .subscribe(() => {
        this.getPacijenti();
        this.toast.showSuccess(this.deleteMessage);
      });
  }

}
