import {Component, OnInit} from '@angular/core';
import {LijekoviRepositoryService} from "../../repositories/lijekovi-repository.service";
import {PagedList} from "../../interfaces/PagedList";
import {HttpClient} from "@angular/common/http";
import {NgToastService} from "ng-angular-popup";
import {DatePipe} from "@angular/common";
import { Router } from '@angular/router';

@Component({
  selector: 'app-lijekovi',
  templateUrl: './lijekovi.component.html',
  styleUrls: ['./lijekovi.component.css']
})
export class LijekoviComponent implements OnInit{
  lijekovi?: PagedList | null;
  filterByNaziv: string = "";
  filterByVrsta: string = "";

  currentPage: number = 1;
  pageSize: number = 10;
  tableSize: number[] = [5, 10, 15, 20];

  editLijek: any = null;
  newLijek: any = null;
  infoLijek: any = null;
  showInfoLijekovi: boolean = false;
  filter = '';

  public pageNumbersArray(): number[] {
    let result = [];

    for (let i = 0; i < this.totalPages(); i++)
      result.push(i + 1);
    return result;
  }

  private totalPages() {
    if (this.lijekovi != null)
      return this.lijekovi!.totalPages;

    return 1;
  }

  constructor(private repository: LijekoviRepositoryService,private httpKlijent: HttpClient, private toast: NgToastService, private datePipe: DatePipe,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.getLijekovi();
  }
  OpenCloseInfoModal($event: any) {
    this.showInfoLijekovi = $event;
  }
  private getLijekovi = () => {
    this.repository.getLijekovi(`Lijek/GetAll?naziv=${this.filterByNaziv}&vrsta=${this.filterByVrsta}&pageNumber=${this.currentPage}&pageSize=${this.pageSize}`)
      .subscribe((lijek:any) => {
        this.lijekovi = lijek;
      })
  }
  IdiNaZahtjeve() {
    this.router.navigateByUrl('/zahtjevi-lijekova')
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
    const deleteUrl: string = `Lijek/Delete/${id}`;

    this.repository.deleteLijek(deleteUrl)
      .subscribe(() =>{
        this.getLijekovi();
      });
  }
  addMedication(){
    this.newLijek = {
      prikaz: true,
      ime: "",
      name: "Dodaj lijek",
    }
  }
  edit(medication: any){
    this.editLijek = medication;
    this.editLijek.name = "Edit medication";
    this.editLijek.prikaz = true;
  }
  moreInfo(medication: any){
    this.infoLijek = medication;
    this.infoLijek.name = "Pregled detalja lijeka";
    this.showInfoLijekovi = true;
  }
}
