/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { NalaziPacijentaComponent } from './nalazi-pacijenta.component';

describe('NalaziPacijentaComponent', () => {
  let component: NalaziPacijentaComponent;
  let fixture: ComponentFixture<NalaziPacijentaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NalaziPacijentaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NalaziPacijentaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
