import { Injectable, OnInit } from '@angular/core';
import { NgToastService } from 'ng-angular-popup';

@Injectable({
  providedIn: 'root'
})
export class ToastService {

  constructor(private toast: NgToastService) { }

  showSuccess(message: string) {
    this.toast.success({ detail: "Success !", summary: message, duration: 3000 });
  }

  showError(message: string) {
    this.toast.error({ detail: "Error !", summary: message, duration: 3000 });
  }

  showInfo(message: string) {
    this.toast.info({ detail: "Info !", summary: message, duration: 3000 });
  }

  showWarning(message: string) {
    this.toast.warning({ detail: "Warning !", summary: message, duration: 3000 });
  }
}