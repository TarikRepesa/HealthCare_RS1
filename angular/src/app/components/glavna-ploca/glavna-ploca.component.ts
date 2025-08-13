import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { PagedList } from 'src/app/interfaces/PagedList';
import { TerminiRepositoryService } from 'src/app/repositories/termini-repository.service';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-glavna-ploca',
  templateUrl: './glavna-ploca.component.html',
  styleUrls: ['./glavna-ploca.component.css']
})
export class GlavnaPlocaComponent implements OnInit {

  appointments: any[] = [];
  todayAppointments: number = 0;
  tomorrowAppointments: number = 0;
  weekAppointments: number = 0;
  todayDate: any;

  isUserLjekar: boolean = false;

  terminiByLjekar?: PagedList | null;
  datum: any = "";

  currentPage: number = 1;
  pageSize: number = 10;
  tableSize: number[] = [5, 10, 15, 20];

  public pageNumbersArray(): number[] {
    let result = [];

    for (let i = 0; i < this.totalPages(); i++)
      result.push(i + 1);
    return result;
  }

  private totalPages() {
    if (this.terminiByLjekar != null)
      return this.terminiByLjekar!.totalPages;

    return 1;
  }

  constructor(private repository: TerminiRepositoryService, private datePipe: DatePipe, private _authSrvice: AuthService) { }

  ngOnInit() {
    this.todayDate = this.datePipe.transform(new Date(), 'yyyy-MM-ddTHH:mm');
    console.log("Today date -> " + this.todayDate)
    this.datum = this.datePipe.transform(new Date(), 'yyyy-MM-dd');
    this.isLjekar();
    this.getTermini();
    this.GetTerminiByLjekar();
  }

  isLjekar() {
    this._authSrvice.checkIfUserIsLjekar()
      .then(res => {
        this.isUserLjekar = res;
      });
  }

  getTermini() {
    this.repository.getTermini('Termin/GetAll')
      .subscribe((result: any) => {
        this.appointments = result;
        this.countAppointments();
      });
  }

  GetTerminiByLjekar() {
    this.repository.getTerminByLjekar(`Termin/GetTerminiByLjekar?datum=${this.datum}&pageNumber=${this.currentPage}&pageSize=${this.pageSize}`)
      .subscribe((result: any) => {
        this.terminiByLjekar = result;
        console.log(this.terminiByLjekar);
      });
  }

  goToPage(p: number) {
    this.currentPage = p;
    this.GetTerminiByLjekar();
  }

  goToPrev() {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.GetTerminiByLjekar();
    }
  }

  goToNext() {
    if (this.currentPage < this.totalPages()) {
      this.currentPage++
      this.GetTerminiByLjekar();
    }
  }

  ReturnToTodaysDate() {
    this.datum = this.datePipe.transform(new Date(), 'yyyy-MM-dd');

    this.currentPage = 1;
    this.GetTerminiByLjekar();
  }

  SearchDate() {
    this.currentPage = 1;

    this.GetTerminiByLjekar();
  }

  countAppointments() {
    const today = new Date();

    const tomorrow = new Date();
    tomorrow.setDate(tomorrow.getDate() + 1);


    this.todayAppointments = this.appointments.filter((x: any) => {
      const appointmentDate = new Date(x.vrijemeOd);
      return appointmentDate.toDateString() === today.toDateString();
    }).length;

    this.tomorrowAppointments = this.appointments.filter((x: any) => {
      const appointmentDate = new Date(x.vrijemeOd);
      return appointmentDate.toDateString() === tomorrow.toDateString();
    }).length;

    const week = new Date();
    week.setDate(week.getDate() + 7);

    this.weekAppointments = this.appointments.filter((x: any) => {
      const appointmentDate = new Date(x.vrijemeOd);
      return appointmentDate <= week && appointmentDate >= today;
    }).length;
  }

  Style(x: any) {
    if (this.todayDate >= x.vrijemeOd && this.todayDate >= x.vrijemeDo) {
      return { 'color': 'black', 'background-color': '#93E9BE' }
    } else {
      return { 'color': 'black', 'background-color': '#ADDFFF' }
    }
  }

}
