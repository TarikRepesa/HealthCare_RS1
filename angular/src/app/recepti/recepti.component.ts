import { Component, OnInit } from '@angular/core';
import { ReceptiRepositoryService } from '../repositories/recepti-repository.service';
import { DatePipe } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { PagedList } from '../interfaces/PagedList';
import { FormControl, FormControlName, FormGroup, Validators } from '@angular/forms';
import { AnyComponent } from '@fullcalendar/core/preact';
import { timestamp } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';
import { ToastService } from '../ngToastService/toast.service';

@Component({
  selector: 'app-recepti',
  templateUrl: './recepti.component.html',
  styleUrls: ['./recepti.component.css']
})
export class ReceptiComponent implements OnInit {

  recepti?: PagedList | null;
  pacijentId: any;
  filter: string = "";

  showEditRecept: boolean = false;
  editRecept: any;
  receptId: number;

  showAddRecept: boolean = false;

  recept: any;
  showInfo: boolean = false;
  deleteMessage: any;

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
    if (this.recepti != null)
      return this.recepti!.totalPages;

    return 1;
  }

  OpenEdit($event: any) {
    this.showEditRecept = $event;
  }

  constructor(private repository: ReceptiRepositoryService, private datePipe: DatePipe, private route: ActivatedRoute, private toast: ToastService, private translate: TranslateService) { }

  ngOnInit() {
    this.route.parent.params.subscribe(params => {
      this.pacijentId = params['id'];
      this.getReceptiByPacijentId();
    });

    this.translateMessage();
  }

  private translateMessage() {
    this.translate.get('DELETE_RECEPT').subscribe((translatedText: string) => {
      this.deleteMessage = translatedText;
    });
  }

  OpenInfo($event: any) {
    this.showInfo = $event;
  }

  OpenAdd($event: any){
    this.showAddRecept = $event;
  }

  getReceptiByPacijentId = () => {
    this.repository.getReceptByPacijentId(`Recept/GetByPacijentId/${this.pacijentId}?sifraBolesti=${this.filter}&pageNumber=${this.currentPage}&pageSize=${this.pageSize}`)
      .subscribe((result: any) => {
        this.recepti = result;
      });
  }

  getRecept(receptId: number) {
    this.repository.getReceptById(`Recept/GetById/${receptId}`)
      .subscribe((result: any) => {
        this.recept = result;
      });
  }

  goToPage(p: number) {
    this.currentPage = p;
    this.getReceptiByPacijentId();
  }

  goToPrev() {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.getReceptiByPacijentId();
    }
  }

  goToNext() {
    if (this.currentPage < this.totalPages()) {
      this.currentPage++
      this.getReceptiByPacijentId();
    }
  }

  Search() {
    this.currentPage = 1;
    this.getReceptiByPacijentId();
  }

  Reset() {
    this.filter = "";

    this.getReceptiByPacijentId();
  }

  Edit(recept: any) {
    this.repository.getReceptById(`Recept/GetById/${recept.receptId}`)
      .subscribe((result: any) => {
        this.editRecept = result;
      });
  }

  Delete(receptId: number) {
    this.repository.deleteRecept('Recept/Delete/' + receptId)
      .subscribe(() => {
        this.toast.showSuccess(this.deleteMessage);
        this.currentPage = 1;
        this.getReceptiByPacijentId();
      });
  }

}
