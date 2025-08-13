import {Component, Input, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {OdjeljenjeRepositoryService} from "../../../repositories/odjeljenje-repository.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-management-add',
  templateUrl: './management-add.component.html',
  styleUrls: ['./management-add.component.css']
})
export class ManagementAddComponent implements OnInit{

  @Input() addOdjeljenje: any;

  bolnice: any;
  bolnicaChosen: any;
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
    ])),
    Bolnica: new FormControl('', Validators.required)
  })
  constructor(private _http: HttpClient, private repository: OdjeljenjeRepositoryService) { }

  ngOnInit(): void {
    this.getBolnice();
  }

  onAddOdjeljenje() {
    let newOdjeljenje = {
      Naziv: this.addOdjeljenje.naziv,
      Vrsta: this.addOdjeljenje.vrsta,
      BolnicaId: this.bolnicaChosen
    }
    const updateUri: string = `Odjeljenje/Add`;
    this.repository.createOdjeljenje(updateUri, newOdjeljenje).subscribe(() =>{
      this.addOdjeljenje = null;
      setTimeout(() => {
        window.location.reload();
      }, 500)
    });
  }
  getBolnice() {
    this.repository.getBolnice('Odjeljenje/GetBolnice')
      .subscribe((result: any) => {
        this.bolnice = result;
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
      { type: 'pattern', message: 'Unesite ispravnu vrstu odjeljenja!' }
    ],
    'Bolnica': [
      { type: 'required', message: 'Odabir bolnice je obavezan!' },
      { type: 'pattern', message: 'Odaberite ispravnu bolnicu!' }
    ],
  }
}
