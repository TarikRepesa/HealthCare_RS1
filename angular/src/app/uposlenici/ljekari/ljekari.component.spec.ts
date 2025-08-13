/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { LjekariComponent } from './ljekari.component';

describe('LjekariComponent', () => {
  let component: LjekariComponent;
  let fixture: ComponentFixture<LjekariComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LjekariComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LjekariComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
