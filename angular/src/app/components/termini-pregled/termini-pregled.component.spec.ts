/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { TerminiPregledComponent } from './termini-pregled.component';

describe('TerminiPregledComponent', () => {
  let component: TerminiPregledComponent;
  let fixture: ComponentFixture<TerminiPregledComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TerminiPregledComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TerminiPregledComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
