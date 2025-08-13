/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ObavijestiComponent } from './obavijesti.component';

describe('ObavijestiComponent', () => {
  let component: ObavijestiComponent;
  let fixture: ComponentFixture<ObavijestiComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ObavijestiComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ObavijestiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
