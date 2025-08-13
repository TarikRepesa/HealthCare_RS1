/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { TehnicariComponent } from './tehnicari.component';

describe('TehnicariComponent', () => {
  let component: TehnicariComponent;
  let fixture: ComponentFixture<TehnicariComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TehnicariComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TehnicariComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
