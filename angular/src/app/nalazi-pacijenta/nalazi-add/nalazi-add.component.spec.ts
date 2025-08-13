/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { NalazAddComponent } from './nalazi-add.component';

describe('NalazAddComponent', () => {
  let component: NalazAddComponent;
  let fixture: ComponentFixture<NalazAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NalazAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NalazAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
