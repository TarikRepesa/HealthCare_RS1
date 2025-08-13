import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';
import { ActivatedRoute } from '@angular/router';
import { PagedList } from '../interfaces/PagedList';
import { TerminiRepositoryService } from '../repositories/termini-repository.service';

@Component({
  selector: 'app-termini',
  templateUrl: './termini.component.html',
  styleUrls: ['./termini.component.css']
})
export class TerminiComponent implements OnInit {

  pacijentId: any;
  termini?: PagedList | null;

  filterByDate: any = "";

  termin: any;
  showInfoTermin: boolean = false;

  currentPage: number = 1;
  pageSize: number = 5;
  tableSize: number[] = [5, 10, 15, 20];

  public pageNumbersArray(): number[] {
    let result = [];

    for (let i = 0; i < this.totalPages(); i++)
      result.push(i + 1);
    return result;
  }

  private totalPages() {
    if (this.termini != null)
      return this.termini!.totalPages;

    return 1;
  }

  constructor(private route: ActivatedRoute, private repository: TerminiRepositoryService) { }

  ngOnInit() {
    this.route.parent.params.subscribe(params => {
      this.pacijentId = params['id'];
      this.getTermini();
    });
  }

  OpenInfo($event: any) {
    this.showInfoTermin = $event;
  }

  getTermini() {
    this.repository.getTerminByPacijentId(`Termin/GetByPacijentId/${this.pacijentId}?datumPosjete=${this.filterByDate}&pageNumber=${this.currentPage}&pageSize=${this.pageSize}`)
      .subscribe((result: any) => {
        this.termini = result;
      });
  }

  getTermin(terminId: number) {
    this.repository.getTerminById(`Termin/GetById/${terminId}`)
      .subscribe((result: any) => {
        this.termin = result;
      });
  }

  goToPage(p: number) {
    this.currentPage = p;
    this.getTermini();
  }

  goToPrev() {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.getTermini();
    }
  }

  goToNext() {
    if (this.currentPage < this.totalPages()) {
      this.currentPage++
      this.getTermini();
    }
  }

  filtriraj() {
    if (!this.filterByDate) {
      return this.termini.dataItems;
    }

    const selectDate = new Date(this.filterByDate);

    return this.termini.dataItems.filter((item: any) => {
      const itemDate = new Date(item.vrijemeOd);

      return itemDate.toDateString() === selectDate.toDateString();
    });
  }

  Search() {
    this.currentPage = 1;
    this.getTermini();
  }

  Reset() {
    this.filterByDate = "";

    this.currentPage = 1;
    this.getTermini();
  }

}
