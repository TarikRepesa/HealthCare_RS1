/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { AsistentiComponent } from './asistenti.component';

describe('AsistentiComponent', () => {
  let component: AsistentiComponent;
  let fixture: ComponentFixture<AsistentiComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AsistentiComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AsistentiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
