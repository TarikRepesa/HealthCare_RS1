import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { Observable, Subject, observable } from 'rxjs';
import { ToastService } from '../ngToastService/toast.service';
import { NgToastService } from 'ng-angular-popup/lib/ng-toast.service';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {

  constructor(public toast: ToastService) { }

  hubConnection: signalR.HubConnection;

  userName: string;

  ssSubj = new Subject<any>();

  ssObs(): Observable<any> {
    return this.ssSubj.asObservable();
  }

  startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:5002/notificationHub', {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
      })
      .build();

    this.hubConnection
      .start()
      .then(() => {
        this.ssSubj.next({ type: "HubConnStarted" });
      })
      .catch(err => console.log('Error while starting connection: ' + err))
  }


  /* public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:5002/notificationHub')
      .build();
    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err))
  } */



  /* public sendMessage(message: string) {
    this.hubConnection.invoke("SendMessage", message)
      .catch(err => console.error('Error while starting connection: ' + err));
  }

  public receiveMessage() {
    this.hubConnection.on("ReceiveMessage", (data) => {
      console.log(data);
    });
  } */

}
