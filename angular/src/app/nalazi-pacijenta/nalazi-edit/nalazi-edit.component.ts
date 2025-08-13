import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { NgToastService } from 'ng-angular-popup';
import { ToastService } from 'src/app/ngToastService/toast.service';
import { NalaziRepositoryService } from 'src/app/repositories/nalazi-repository.service';
import { EnvironmentUrlService } from 'src/app/shared/services/environment-url.service';

@Component({
  selector: 'app-nalazi-edit',
  templateUrl: './nalazi-edit.component.html',
  styleUrls: ['./nalazi-edit.component.css']
})
export class NalaziEditComponent implements OnInit {

  @Input()
  editNalaz: any;

  @Input()
  nalazId: number;

  @Output()
  open = new EventEmitter<boolean>();

  show: boolean = true;
  editMessage: any;

  form = new FormGroup({
    Vrsta: new FormControl('', Validators.compose([
      Validators.minLength(2),
      Validators.maxLength(50),
      Validators.required
    ])),
    Prioritet: new FormControl('', Validators.compose([
      Validators.minLength(2),
      Validators.maxLength(50),
      Validators.required
    ])),
  });

  constructor(private repository: NalaziRepositoryService, private toast: ToastService, private translate: TranslateService) { }

  ngOnInit() {
    this.translateMessage();
  }

  private translateMessage() {
    this.translate.get('EDIT_NALAZ').subscribe((translatedText: string) => {
      this.editMessage = translatedText;
    });
  }

  Close() {
    this.show = !this.show;
    this.open.emit(this.show);
  }

  SaveChanges() {

    let editNalaz = {
      ljekarId: this.editNalaz.ljekarId,
      vrsta: this.editNalaz.vrsta,
      prioritet: this.editNalaz.prioritet
    }

    this.repository.updateNalaz(`Nalaz/Edit/${this.nalazId}`, editNalaz)
      .subscribe(() => {
        this.toast.showSuccess(this.editMessage);
        this.Close();
        setTimeout(() => {
          window.location.reload();
        }, 2000)
      })
  }

  form_validation_messages = {
    'Vrsta': [
      { type: 'minlength', message: 'Vrsta.minlength' },
      { type: 'maxlength', message: 'Vrsta.maxlength' },
      { type: 'required', message: 'Vrsta.required' }
    ],
    'Prioritet': [
      { type: 'minlength', message: 'Prioritet.minlength' },
      { type: 'maxlength', message: 'Prioritet.maxlength' },
      { type: 'required', message: 'Prioritet.required' }
    ]
  }
}
