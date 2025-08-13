import {Component, OnInit} from '@angular/core';
import {OdjeljenjeRepositoryService} from "../../repositories/odjeljenje-repository.service";
import {Odjeljenje} from "../../interfaces/odjeljenje";
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-management',
  templateUrl: './management.component.html',
  styleUrls: ['./management.component.css']
})
export class ManagementComponent implements OnInit{
  public odjeljenje: Odjeljenje[];
  editOdjeljenje: any = null;
  newOdjeljenje: any = null;
  filter = '';

  constructor(private repositoryOdjeljenje: OdjeljenjeRepositoryService, private translate: TranslateService) { }

  ngOnInit(): void {
    this.getOdjeljenje();
  }
  private getOdjeljenje = () => {
    this.repositoryOdjeljenje.getOdjeljenje('Odjeljenje/GetAll')
      .subscribe(odjeljenje => {
        this.odjeljenje = odjeljenje as Odjeljenje[];
      })
  }
  OnRemoveOdjeljenje = (id:number) => {
    const deleteUrl: string = `Odjeljenje/Delete/${id}`;

    this.repositoryOdjeljenje.deleteOdjeljenje(deleteUrl)
      .subscribe(() =>{
        this.getOdjeljenje();
      });
  }
  addOdjeljenje(){
    this.newOdjeljenje = {
      prikaz: true,
      ime: "",
      name: "Dodaj Odjeljenje",
    }
  }
  edit(odjeljenje: any){
    this.editOdjeljenje = odjeljenje;
    this.editOdjeljenje.name = "Edit odjeljenje";
    this.editOdjeljenje.prikaz = true;
  }
  filterOdjeljenje(){
    if(this.odjeljenje == null) return[];
    return this.odjeljenje.filter( (x) => `${x.naziv}`
      .toLowerCase().
      startsWith(this.filter.toLowerCase())
    );
  }
}
