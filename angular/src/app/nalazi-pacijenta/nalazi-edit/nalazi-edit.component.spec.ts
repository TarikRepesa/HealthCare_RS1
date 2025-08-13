/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { NalaziEditComponent } from './nalazi-edit.component';

describe('NalaziEditComponent', () => {
  let component: NalaziEditComponent;
  let fixture: ComponentFixture<NalaziEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NalaziEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NalaziEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
