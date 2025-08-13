import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {DatePipe} from "@angular/common";
import { NalaziPregledRepositoryService } from 'src/app/repositories/nalazi-pregled-repository.service';
import { AuthService } from 'src/app/shared/services/auth.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-nalazi-pregled',
  templateUrl: './nalazi-pregled.component.html',
  styleUrl: './nalazi-pregled.component.css'
})
export class NalaziPregledComponent implements OnInit {

  pacijentId: any;
  nalazi: any;

  isUserPacijent: boolean;

  currentPage: number = 1;
  pageSize: number = 5;
  tableSize: number[] = [5, 10, 15, 20];

  constructor(private repository: NalaziPregledRepositoryService, private route: ActivatedRoute, private datePipe: DatePipe , private _authService: AuthService, private translate: TranslateService) { }

  ngOnInit(): void {
    this.isPacijent();
    this.pacijentId = this._authService.GetUserId();
    this.GetByPacijentId(); 
  }

  GetByPacijentId = () => {
    this.repository.GetByPacijentId(`NalazPregled/GetByPacijentId?id=${this.pacijentId}&pageNumber=${this.currentPage}&pageSize=${this.pageSize}`)
      .subscribe((result: any) => {
        this.nalazi = result;
      });
  }

  public isPacijent = () => {
    return this._authService.checkIfUserIsPacijent()
      .then(res => {
        this.isUserPacijent = res;
      })
  }

  public pageNumbersArray(): number[] {
    let result = [];

    for (let i = 0; i < this.totalPages(); i++)
      result.push(i + 1);
    return result;
  }

  private totalPages() {
    if (this.nalazi != null)
      return this.nalazi!.totalPages;

    return 1;
  }

  goToPage(p: number) {
    this.currentPage = p;
    this.GetByPacijentId();
  }

  goToPrev() {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.GetByPacijentId();
    }
  }

  goToNext() {
    if (this.currentPage < this.totalPages()) {
      this.currentPage++
      this.GetByPacijentId();
    }
  }

}
