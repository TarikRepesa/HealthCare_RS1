import { HttpErrorResponse } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { catchError, throwError } from 'rxjs';
import { ToastService } from 'src/app/ngToastService/toast.service';
import { TerminiRepositoryService } from 'src/app/repositories/termini-repository.service';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-termin-detail',
  templateUrl: './termin-detail.component.html',
  styleUrls: ['./termin-detail.component.css']
})
export class TerminDetailComponent implements OnInit {

  @Input()
  termin: any;

  @Output()
  Open_Close_DetailModal = new EventEmitter<boolean>();

  show: boolean = true;

  datumPosjete: any;
  pocetakPosjete: any;
  krajPosjete: any;

  noviTermin: boolean = true;
  isButtonDisabled: boolean = true;

  editMessageSuccess: any;
  editMessageError: any;
  deleteMessageSuccess: any;
  deleteMessageError: any;

  isUserPacijent: boolean = false;

  constructor(private repository: TerminiRepositoryService, private toastService: ToastService, private translate: TranslateService, private _authService: AuthService) { }

  ngOnInit() {
    this.isPacijent();
    this.translateMessage();
  }

  private translateMessage() {
    this.translate.get('TERMIN_EDIT_SUCCESS').subscribe((translatedText: string) => {
      this.editMessageSuccess = translatedText;
    });

    this.translate.get('TERMIN_EDIT_ERROR').subscribe((translatedText: string) => {
      this.editMessageError = translatedText;
    });

    this.translate.get('TERMIN_DELETE_SUCCESS').subscribe((translatedText: string) => {
      this.deleteMessageSuccess = translatedText;
    });

    this.translate.get('TERMIN_DELETE_ERROR').subscribe((translatedText: string) => {
      this.deleteMessageError = translatedText;
    });
  }

  public isPacijent = () => {
    return this._authService.checkIfUserIsPacijent()
      .then(res => {
        this.isUserPacijent = res;
      })
  }

  Close() {
    this.show = !this.show;
    this.Open_Close_DetailModal.emit(this.show);
  }

  ponistiPromjene() {
    this.isButtonDisabled = true;

    this.datumPosjete = null;
    this.pocetakPosjete = null;
    this.krajPosjete = null;
  }

  onInputChange() {
    if (this.datumPosjete != null && this.pocetakPosjete != null && this.krajPosjete != null)
      this.isButtonDisabled = false;
    else
      this.isButtonDisabled = true;
  }

  pomjeriPosjetu() {
    let termin = {
      pocetakPosjete: new Date(this.datumPosjete + ' ' + this.pocetakPosjete + ' UTC').toISOString(),
      krajPosjete: new Date(this.datumPosjete + ' ' + this.krajPosjete + ' UTC').toISOString()
    }

    this.repository.updateTermin('Termin/Edit/' + this.termin.terminId, termin)
      .subscribe(() => {
        this.toastService.showSuccess(this.editMessageSuccess);
        this.Close();

        setTimeout(() => {
          window.location.reload();
        }, 3000);
      }, error => {
        this.toastService.showError(this.editMessageError);
      });
  }

  OtkaziTermin() {
    this.repository.deleteTermin('Termin/Delete/' + this.termin.terminId)
      .subscribe(() => {
        this.toastService.showSuccess(this.deleteMessageSuccess);
        this.Close();

        setTimeout(() => {
          window.location.reload();
        }, 3000);
      }, error => {
        this.toastService.showError(this.deleteMessageError);
      });
  }
}
