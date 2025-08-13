import {Component, OnInit} from '@angular/core';
import { LijekoviRepositoryService } from './../repositories/lijekovi-repository.service';

@Component({
  selector: 'app-privacy',
  templateUrl: './privacy.component.html',
  styleUrls: ['./privacy.component.css']
})
export class PrivacyComponent implements OnInit{
  public claims: [] = [];
  constructor(private _repository: LijekoviRepositoryService) { }
  ngOnInit(): void {
    this.getClaims();
  }
  public getClaims = () =>{
    this._repository.getLijekovi('Lijekovi/Privacy')
      .subscribe(res => {
        this.claims = res as [];
      })
  }
}
