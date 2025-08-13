import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { NgToastService } from 'ng-angular-popup';
import { ToastService } from 'src/app/ngToastService/toast.service';
import { ReceptiRepositoryService } from 'src/app/repositories/recepti-repository.service';
import { EnvironmentUrlService } from 'src/app/shared/services/environment-url.service';

@Component({
  selector: 'app-recepti-edit',
  templateUrl: './recepti-edit.component.html',
  styleUrls: ['./recepti-edit.component.css']
})
export class ReceptiEditComponent implements OnInit {

  @Input()
  editRecept: any;

  @Input()
  receptId: number;

  @Output()
  open = new EventEmitter<boolean>();

  show: boolean = true;
  editMessage: any;

  form = new FormGroup({
    SifraBolesti: new FormControl('', Validators.compose([
      Validators.pattern('^[A-Z]{1}[0-9]{2}\\s+[A-Z]{1}[0-9]{2}$'),
      Validators.required
    ])),
    Doza: new FormControl('', Validators.compose([
      Validators.minLength(2),
      Validators.maxLength(10),
      Validators.required
    ])),
    Napomena: new FormControl('', Validators.compose([
      Validators.minLength(2),
      Validators.maxLength(500),
      Validators.required
    ])),
  });

  constructor(private repository: ReceptiRepositoryService, private toast: ToastService, private translate: TranslateService) { }

  ngOnInit() {
    this.translateMessage();
  }

  private translateMessage() {
    this.translate.get('EDIT_RECEPT').subscribe((translatedText: string) => {
      this.editMessage = translatedText;
    });
  }

  Close() {
    this.show = !this.show;
    this.open.emit(this.show);
  }

  SaveChanges() {

    let editRecept = {
      ljekarId: this.editRecept.ljekarId,
      doza: this.editRecept.doza,
      napomena: this.editRecept.napomena,
      sifraBolesti: this.editRecept.sifraBolesti
    }

    this.repository.updateRecept(`Recept/Edit/${this.receptId}`, editRecept)
      .subscribe(() => {
        this.toast.showSuccess(this.editMessage);
        this.Close();
        setTimeout(() => {
          window.location.reload();
        }, 2000)
      })
  }

  form_validation_messages = {
    'SifraBolesti': [
      { type: 'pattern', message: 'SifraBolesti.pattern' },
      { type: 'required', message: 'SifraBolesti.required' }
    ],
    'Doza': [
      { type: 'minlength', message: 'Doza.minlength' },
      { type: 'maxlength', message: 'Doza.maxlength' },
      { type: 'required', message: 'Doza.required' }
    ],
    'Napomena': [
      { type: 'minlength', message: 'Napomena.minlength' },
      { type: 'maxlength', message: 'Napomena.maxlength' },
      { type: 'required', message: 'Napomena.required' }
    ]
  }
}
