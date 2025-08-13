import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';
import { ActivatedRoute } from '@angular/router';
import { UputniceRepositoryService } from '../repositories/uputnice-repository.service';
import { ReactiveFormsModule } from '@angular/forms';
import { NgToastService } from 'ng-angular-popup';
import { ToastService } from '../ngToastService/toast.service';
import { PagedList } from '../interfaces/PagedList';
import { TranslateService } from '@ngx-translate/core';


@Component({
  selector: 'app-uputnice-pacijenta',
  templateUrl: './uputnice-pacijenta.component.html',
  styleUrls: ['./uputnice-pacijenta.component.css']
})
export class UputnicePacijentaComponent implements OnInit {

  uputnice: any;
  pacijentId: any;

  uputnicaId: number;

  showAddUputnica: boolean = false;

  showEditUputnica: boolean = false;
  editUputnica: any; 

  deleteMessage: any; 

  filter: string = "";

  currentPage: number = 1;
  pageSize: number = 5;
  tableSize: number[] = [5, 10, 15, 20];


  constructor(private repository: UputniceRepositoryService, private httpKlijent: HttpClient, private url: EnvironmentUrlService, private route: ActivatedRoute, private toast: ToastService, private translate: TranslateService) { }

  public pageNumbersArray(): number[] {
    let result = [];

    for (let i = 0; i < this.totalPages(); i++)
      result.push(i + 1);
    return result;
  }

  private totalPages() {
    if (this.uputnice != null)
      return this.uputnice!.totalPages;

    return 1;
  }

  ngOnInit() {
    this.route.parent.params.subscribe(params => {
      this.pacijentId = params['id'];
      this.loadData();
    });
    this.translateMessage();
  }

  private translateMessage() {
    this.translate.get('DELETE_UPUTNICA').subscribe((translatedText: string) => {
      this.deleteMessage = translatedText;
    });
  }
  
  loadData() {
    this.repository.getByPacijentId(this.pacijentId + `?dijagnoza=${this.filter}&pageNumber=${this.currentPage}&pageSize=${this.pageSize}`).subscribe((result: any ) => {
      this.uputnice = result;
    });
  }
  
  goToPage(p: number) {
    this.currentPage = p;
    this.loadData();
  }

  goToPrev() {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.loadData();
    }
  }

  goToNext() {
    if (this.currentPage < this.totalPages()) {
      this.currentPage++
      this.loadData();
    }
  }

  Reset() {
    this.filter = "";
    this.loadData();
  }

  Search() {
    this.currentPage = 1;
    this.loadData();
  }

  OpenAdd($event: any){
    this.showAddUputnica = $event;
  }

  OpenEdit($event: boolean) {
    this.showEditUputnica = $event;
    if(!$event) {
      this.editUputnica = null;
    }
  }

  Edit(uputnica: any) {
    this.repository.getById(`Uputnica/getById/${uputnica.uputnicaId}`)
      .subscribe((result: any) => {
        this.editUputnica = result;
      });
  }

  getByPacijentId = () => {
    this.repository.getByPacijentId(`Uputnica/GetByPacijentId/${this.pacijentId}`)
      .subscribe((result: any) => {
        this.uputnice = result;
      });
  }

  obrisiUputnicu(uputnicaId: any) {
    this.repository.deleteUputnica('Uputnica/Delete/' + uputnicaId)
    .subscribe(() => {
      this.toast.showSuccess("Uputnica uspjesno obrisana!");
      this.loadData();
    });
  }


}
