import { Component, OnInit } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { dA, er } from '@fullcalendar/core/internal-common';
import { AnyComponent } from '@fullcalendar/core/preact';
import { TranslateService } from '@ngx-translate/core';
import { Observable, Subject } from 'rxjs';
import { SignalRService } from 'src/app/SignalR/signalR.service';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-obavijesti',
  templateUrl: './obavijesti.component.html',
  styleUrls: ['./obavijesti.component.css']
})
export class ObavijestiComponent implements OnInit {

  isUserLjekar: boolean = false;
  isUserAsistent: boolean = false;
  isUserTehnicar: boolean = false;

  data: any;
  poruka: any;
  userId: any;
  total: number;

  successMessage: any;
  errorMessage: any;
  removeMessage: any;

  constructor(public signalrService: SignalRService, private _authService: AuthService, private translate: TranslateService) { }

  ngOnInit() {
    this.isLjekar();
    this.isAsistent(),
    this.isTehnicar();

    this.signalrService.startConnection();
    this.getUserId();

    this.getObavijestiResponse();

    this.translateMessage();

    this.signalrService.ssSubj.subscribe((obj: any) => {
      if (obj.type == "HubConnStarted") {
        this.getObavijesti();
      }
    });

    this.sendNotificationResponseSuccess();
    this.sendNotificationResponseFail();

    this.removeNotificationResponseSuccess();
    this.removeNotificationResponseFail();
  }

  private translateMessage() {

    this.translate.get('SUCCESS_MESSAGE').subscribe((translatedText: string) => {
      this.successMessage = translatedText;
    });

    this.translate.get('ERROR_MESSAGE').subscribe((translatedText: string) => {
      this.errorMessage = translatedText;
    });

    this.translate.get('REMOVE_MESSAGE').subscribe((translatedText: string) => {
      this.removeMessage = translatedText;
    });
    
  }

  getUserId() {
    this.userId = this._authService.GetUserId();
  }

  SendNotification() {
    this.signalrService.hubConnection.invoke("SendNotification", this.userId, this.poruka)
      .catch(err => console.error(err));
  }

  getObavijesti() {
    this.signalrService.hubConnection.invoke("GetObavijesti")
      .catch(err => console.error(err));
  }

  RemoveNotification(id: any) {
    this.signalrService.hubConnection.invoke("RemoveNotification", id, this.userId)
      .catch(err => console.error(err));
  }

  private getObavijestiResponse() {
    this.signalrService.hubConnection.on("GetObavijestiResponse", (data) => {
      this.data = data;
      this.total = data.length;
    });
  }

  private sendNotificationResponseSuccess() {
    this.signalrService.hubConnection.on("SendNotificationResponseSuccess", () => {
      this.getObavijesti();
      this.poruka = "";
      this.signalrService.toast.showInfo(this.successMessage);
    });
  }

  private sendNotificationResponseFail() {
    this.signalrService.hubConnection.on("SendNotificationResponseFail", () => {
      this.signalrService.toast.showError(this.errorMessage);
    });
  }

  private removeNotificationResponseSuccess() {
    this.signalrService.hubConnection.on("RemoveNotificationResponseSuccess", () => {
      this.getObavijesti();
      this.signalrService.toast.showSuccess(this.removeMessage);
    });
  }

  private removeNotificationResponseFail() {
    this.signalrService.hubConnection.on("RemoveNotificationResponseFail", () => {
      this.signalrService.toast.showError("Neuspjesno uklanjanje obavijesti!");
    });
  }

  public isLjekar = () => {
    return this._authService.checkIfUserIsLjekar()
      .then(res => {
        this.isUserLjekar = res;
      })
  }

  public isAsistent = () => {
    return this._authService.checkIfUserIsAsistent()
      .then(res => {
        this.isUserAsistent = res;
      })
  }

  public isTehnicar = () => {
    return this._authService.checkIfUserIsTehnicar()
      .then(res => {
        this.isUserTehnicar = res;
      })
  }
}
