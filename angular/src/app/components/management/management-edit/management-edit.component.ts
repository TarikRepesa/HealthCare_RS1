import {Component, Input, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {OdjeljenjeRepositoryService} from "../../../repositories/odjeljenje-repository.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-management-edit',
  templateUrl: './management-edit.component.html',
  styleUrls: ['./management-edit.component.css']
})
export class ManagementEditComponent implements OnInit{
  @Input() urediOdjeljenje:any;
  form = new FormGroup({
    Naziv: new FormControl('', Validators.compose([
      Validators.maxLength(25),
      Validators.minLength(5),
      Validators.pattern('^[A-Z][a-z_\\-]+$'),
      Validators.required
    ])),
    Vrsta: new FormControl('', Validators.compose([
      Validators.maxLength(25),
      Validators.minLength(5),
      Validators.pattern('^[A-Z][a-z_\\-]+$'),
      Validators.required
    ]))
  })
  constructor(private _http: HttpClient, private repository: OdjeljenjeRepositoryService) { }

  ngOnInit(): void {

  }
  onEditOdjeljenje () {
    const updateUri: string = `Odjeljenje/Update/${this.urediOdjeljenje.id}`;
    this.repository.updateOdjeljenje(updateUri, this.urediOdjeljenje).subscribe(() =>{
      this.urediOdjeljenje.prikaz = false;
      setTimeout(() => {
        window.location.reload();
      }, 500)
    });
  }
  form_validation_messages = {
    'Naziv': [
      { type: 'minlength', message: 'Naziv mora biti duzi od 5 slova!' },
      { type: 'maxlength', message: 'Naziv ne smije biti duzi od 25 slova!' },
      { type: 'required', message: 'Unos naziva je obavezan!' },
      { type: 'pattern', message: 'Unesite ispravan naziv!' }
    ],
    'Vrsta': [
      { type: 'minlength', message: 'Vrsta mora biti duzi od 5 slova!' },
      { type: 'maxlength', message: 'Vrsta ne smije biti duzi od 25 slova!' },
      { type: 'required', message: 'Unos vrste je obavezno!' },
      { type: 'pattern', message: 'Unesite ispravnu vrstu osoblja!' }
    ],
    'Bolnica': [
      { type: 'required', message: 'Odabir bolnice je obavezan!' },
      { type: 'pattern', message: 'Odaberite ispravnu bolnicu!' }
    ],
  }
}
