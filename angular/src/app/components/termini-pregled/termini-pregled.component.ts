import { DatePipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CalendarOptions, EventInput } from '@fullcalendar/core';
import { disableCursor } from '@fullcalendar/core/internal';
import { AnyComponent } from '@fullcalendar/core/preact';
import dayGridPlugin from '@fullcalendar/daygrid';
import interactionPlugin from '@fullcalendar/interaction'
import timeGridPlugin from '@fullcalendar/timegrid';
import { TranslateService } from '@ngx-translate/core';
import { TerminiRepositoryService } from 'src/app/repositories/termini-repository.service';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-termini-pregled',
  templateUrl: './termini-pregled.component.html',
  styleUrls: ['./termini-pregled.component.css']
})
export class TerminiPregledComponent implements OnInit {

  calendarOptions: CalendarOptions = {
    initialView: 'timeGridWeek',
    plugins: [dayGridPlugin, timeGridPlugin, interactionPlugin],
    weekends: false,
    customButtons: {
      show_Weekends: {
        text: '',
        click: () => this.toggleWeekends()
      },
      zakaziTermin: {
        text: '',
        click: () => this.showAddTerminModal(),
      }
    },
    headerToolbar: {
      left: 'dayGridMonth,timeGridWeek,timeGridDay show_Weekends',
      center: 'title',
      right: 'zakaziTermin prev today next'
    },
    eventTimeFormat: {
      hour: '2-digit',
      minute: '2-digit',
      hour12: false
    },
    slotLabelFormat: {
      hour: '2-digit',
      minute: '2-digit',
      hour12: false
    },
    height: 750,
    eventClick: this.Show_Detail_Termin.bind(this),
    dateClick: this.Show_Add_Termin.bind(this),
  };

  eventsPromise: Promise<EventInput>;
  appointments: any[] = [];
  termini: any;
  termin: any;

  datumPosjete: any;
  vrijemePosjeteOd: any;

  showAddTermin: boolean = false;
  showDetailTermin: boolean = false;
  showConfirmModal: boolean = false;

  buttonZakaziTerminTxt: any;

  message: string;
  makeAppointmentMessage: any;

  isUserPacijent: boolean = false;

  constructor(private repository: TerminiRepositoryService, private datePipe: DatePipe, private translate: TranslateService, private _authService: AuthService) {
  }

  ngOnInit() {
    this.isPacijent();
    this.getTermini();
    this.translateFullCalendarOptions();
  }

  private translateFullCalendarOptions() {

    this.translate.get('CALENDAR_BUTTON_SHOW_WEEKEND').subscribe((translatedText: string) => {
      this.calendarOptions.customButtons.show_Weekends.text = translatedText;
    });

    this.translate.get('CALENDAR_BUTTON_ADD').subscribe((translatedText: string) => {
      this.calendarOptions.customButtons.zakaziTermin.text = translatedText;
    });

    this.translate.get('ZakaziTermin').subscribe((translatedText: string) => {
      this.makeAppointmentMessage = translatedText;
    });
  }

  public isPacijent = () => {
    return this._authService.checkIfUserIsPacijent()
      .then(res => {
        this.isUserPacijent = res;
      })
  }

  OpenCloseAddModal($event: any) {
    this.showAddTermin = $event;
  }

  OpenCloseDetailModal($event: any) {
    this.showDetailTermin = $event;
  }

  OpenCloseConfirmModal($event: any) {
    this.showConfirmModal = $event;
  }

  toggleWeekends() {
    this.calendarOptions.weekends = !this.calendarOptions.weekends;
  }

  Show_Add_Termin(arg: any) {
    this.datumPosjete = this.datePipe.transform(arg.date, 'yyyy-MM-dd');
    this.vrijemePosjeteOd = this.datePipe.transform(arg.date, 'HH:mm');

    this.message = `${this.makeAppointmentMessage} ${this.datumPosjete} ${this.vrijemePosjeteOd} ?`;

    this.showConfirmModal = true;
  }

  Show_Detail_Termin(arg: any) {
    this.showDetailTermin = true;

    this.repository.getTerminById('Termin/GetById/' + arg.event.id)
      .subscribe((result: any) => {
        this.termin = result;
      });
  }

  showAddTerminModal() {
    this.datumPosjete = this.datePipe.transform(new Date(), 'yyyy-MM-dd');
    this.vrijemePosjeteOd = null;

    this.showAddTermin = true;
  }

  getTermini() {
    this.repository.getTermini('Termin/GetAll')
      .subscribe((result: any) => {
        this.appointments = result.map((e: any) => ({
          id: e.terminId, title: e.vrsta, start: e.vrijemeOd, end: e.vrijemeDo
        }));

        this.calendarOptions = {
          initialView: 'timeGridWeek',
          events: this.appointments,
        };
      });
  }

}
