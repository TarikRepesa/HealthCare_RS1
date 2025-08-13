import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute} from "@angular/router";
import {EnvironmentUrlService} from "../../../shared/services/environment-url.service";
import {Osoblje} from "../../../interfaces/osoblje";
import {OsobljeRepositoryService} from "../../../repositories/osoblje-repository.service";

@Component({
  selector: 'app-osoblje',
  templateUrl: './osoblje.component.html',
  styleUrls: ['./osoblje.component.css']
})
export class OsobljeComponent implements OnInit{
  id:any;
  osoblje: any[];
  editOsoblje: any = null;
  newOsoblje: any = null;
  filter = '';
  constructor(private _http: HttpClient,private route: ActivatedRoute, private url: EnvironmentUrlService, private repositoryOsoblje: OsobljeRepositoryService) { }
  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = +params['id'];
      this.loadOsoblje();
    });
  }
  loadOsoblje() {
    this._http.get(this.url.urlAddress + '/Osoblje/GetByOdjeljenje/' + this.id).
    subscribe((x: any) => {
      this.osoblje = x as Osoblje[];
    });
  }
  OnRemoveOsoblje = (id:number) => {
    const deleteUrl: string = `Osoblje/Delete/${id}`;

    this.repositoryOsoblje.deleteOsoblje(deleteUrl)
      .subscribe(() =>{
        this.loadOsoblje();
      });
  }
  addOsoblje(){
    this.newOsoblje = {
      prikaz: true,
      ime: "",
      name: "Dodaj Osoblje",
    }
  }
  edit(osoblje: any){
    this.editOsoblje = osoblje;
    this.editOsoblje.name = "Edit osoblje";
    this.editOsoblje.prikaz = true;
  }
  filterOsoblje(){
    if(this.osoblje == null) return[];
    return this.osoblje.filter( (x) => `${x.ime}`
      .toLowerCase().
      startsWith(this.filter.toLowerCase())
    );
  }
}
