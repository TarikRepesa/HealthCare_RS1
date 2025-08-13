import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PagedList } from '../interfaces/PagedList';
import { DatePipe } from '@angular/common';
import { TranslateService } from '@ngx-translate/core';
import { ToastService } from '../ngToastService/toast.service';
import { NalaziRepositoryService } from '../repositories/nalazi-repository.service';

@Component({
  selector: 'app-nalazi-pacijenta',
  templateUrl: './nalazi-pacijenta.component.html',
  styleUrls: ['./nalazi-pacijenta.component.css']
})
export class NalaziPacijentaComponent implements OnInit {

  nalazi: PagedList | null;
  pacijentId: any;

  currentPage: number = 1;
  pageSize: number = 5;
  tableSize: number[] = [5, 10, 15, 20];

  filter: string = "";

  showEditNalaz: boolean = false;
  editNalaz: any;
  nalazId: number;

  showAddNalaz: boolean = false;

  nalaz: any;
  showInfo: boolean = false;
  deleteMessage: any;

  constructor(private repository: NalaziRepositoryService, private datePipe: DatePipe, private route: ActivatedRoute, private toast: ToastService, private translate: TranslateService) { }

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

  OpenEdit($event: any) {
    this.showEditNalaz = $event;
  }

  ngOnInit() {
    this.route.parent.params.subscribe(params => {
      this.pacijentId = params['id'];
      this.getNalaziByPacijentId();
    });

    this.translateMessage();
  }

  private translateMessage() {
    this.translate.get('DELETE_NALAZ').subscribe((translatedText: string) => {
      this.deleteMessage = translatedText;
    });
  }

  OpenInfo($event: any) {
    this.showInfo = $event;
  }

  OpenAdd($event: any){
    this.showAddNalaz = $event;
  }

  getNalaziByPacijentId = () => {
    this.repository.getNalazByPacijentId(`Nalaz/GetByPacijentId/${this.pacijentId}?vrsta=${this.filter}&pageNumber=${this.currentPage}&pageSize=${this.pageSize}`)
      .subscribe((result: any) => {
        this.nalazi = result;
      });
  }

  getNalaz(nalazId: number) {
    this.repository.getNalazById(`Nalaz/GetById/${nalazId}`)
      .subscribe((result: any) => {
        this.nalaz = result;
      });
  }

  goToPage(p: number) {
    this.currentPage = p;
    this.getNalaziByPacijentId();
  }

  goToPrev() {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.getNalaziByPacijentId();
    }
  }

  goToNext() {
    if (this.currentPage < this.totalPages()) {
      this.currentPage++
      this.getNalaziByPacijentId();
    }
  }

  Search() {
    this.currentPage = 1;
    this.getNalaziByPacijentId();
  }

  Reset() {
    this.filter = "";

    this.getNalaziByPacijentId();
  }

  Edit(nalaz: any) {
    this.repository.getNalazById(`Nalaz/GetById/${nalaz.nalazId}`)
      .subscribe((result: any) => {
        this.editNalaz = result;
      });
  }

  Delete(nalazId: number) {
    this.repository.deleteNalaz('Nalaz/Delete/' + nalazId)
      .subscribe(() => {
        this.toast.showSuccess(this.deleteMessage);
        this.currentPage = 1;
        this.getNalaziByPacijentId();
      });
  }

}
