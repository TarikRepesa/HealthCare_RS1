import {Component, OnInit} from '@angular/core';
import {LijekoviRepositoryService} from "../../repositories/lijekovi-repository.service";
import {PagedList} from "../../interfaces/PagedList";
import {HttpClient} from "@angular/common/http";
import {NgToastService} from "ng-angular-popup";
import {DatePipe} from "@angular/common";
import { ZahtjeviLijekovaRepositoryService } from 'src/app/repositories/zahtjevi-lijekova-repository.service';
import { AuthService } from 'src/app/shared/services/auth.service';
import { ToastService } from 'src/app/ngToastService/toast.service';
import { TranslateService } from '@ngx-translate/core';


@Component({
  selector: 'app-lijekovi',
  templateUrl: './zahtjevi-lijekova.component.html',
  styleUrls: ['./zahtjevi-lijekova.component.css']
})
export class ZahtjeviLijekovaComponent implements OnInit{
  zahtjevi?: PagedList | null;
  filterByNaziv: string = "";
  filterByVrsta: string = "";

  currentPage: number = 1;
  pageSize: number = 5;
  tableSize: number[] = [5, 10, 15, 20];

  zahtjevMessage ="Zahtjev uspjesno poslan!";

  newZahtjev: any = null;
  filter = '';
  isUserLjekar: boolean;
  isUserFarmaceut: boolean;

  public pageNumbersArray(): number[] {
    let result = [];

    for (let i = 0; i < this.totalPages(); i++)
      result.push(i + 1);
    return result;
  }

  private totalPages() {
    if (this.zahtjevi != null)
      return this.zahtjevi!.totalPages;

    return 1;
  }
  constructor(private repository: ZahtjeviLijekovaRepositoryService, private httpKlijent: HttpClient, private toast: ToastService, private datePipe: DatePipe, private _authService: AuthService, private translate: TranslateService) { }

  ngOnInit(): void {
    this.getLijekovi();
    this.isLjekar();
    this.isFarmaceut();
    this.translateMessage();
  }

  private translateMessage() {
    this.translate.get('ZAHTJEV_POSLAN').subscribe((translatedText: string) => {
      this.zahtjevMessage = translatedText;
    });
  }


  public isLjekar = () => {
    return this._authService.checkIfUserIsLjekar()
      .then(res => {
        this.isUserLjekar = res;
      })
  }
  public isFarmaceut = () => {
    return this._authService.checkIfUserIsFarmaceut()
      .then(res => {
        this.isUserFarmaceut = res;
      })
  }

  private getLijekovi = () => {
    this.repository.getZahtjeviLijekova(`ZahtjevLijek/GetAll?naziv=${this.filterByNaziv}&pageNumber=${this.currentPage}&pageSize=${this.pageSize}`)
      .subscribe((zahtjev:any) => {
        this.zahtjevi = zahtjev;
      })
  }
  goToPage(p: number) {
    this.currentPage = p;
    this.getLijekovi();
  }

  goToPrev() {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.getLijekovi();
    }
  }

  goToNext() {
    if (this.currentPage < this.totalPages()) {
      this.currentPage++
      this.getLijekovi();
    }
  }

  onTableSizeChange(event: any) {
    console.log(event);
    this.pageSize = event.target.value;
    this.currentPage = 1;
    this.getLijekovi();
  }
  Search() {
    this.currentPage = 1;
    this.getLijekovi();
  }

  Reset() {
    this.filterByNaziv = "";
    this.filterByVrsta = "";

    this.getLijekovi();
  }

  OnRemoveLijek = (id:number) => {
    const deleteUrl: string = `ZahtjevLijek/Delete/${id}`;

    this.repository.deleteZahtjev(deleteUrl)
      .subscribe(() =>{
        this.getLijekovi();
    });
    this.toast.showInfo("Zahtjev otkazan!");
  }

  odobri = (id:number) => {
    const url: string = `ZahtjevLijek/Odobri/${id}`;

    this.repository.odobriZahtjev(url)
      .subscribe(() =>{
        this.getLijekovi();
    });
    this.toast.showInfo("Odobrili ste zahtjev!");
  }

  odbij = (id:number) => {
    const url: string = `ZahtjevLijek/Odbij/${id}`;

    this.repository.odbijZahtjev(url)
      .subscribe(() =>{
        this.getLijekovi();
    });
    this.toast.showInfo("Odbili ste zahtjev!");
  }

  addZahtjev(){
    this.newZahtjev = {
      prikaz: true,
      ime: "",
      name: "Zatrazi lijekove",
    } 
  }
}
