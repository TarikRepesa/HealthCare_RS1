/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { UputnicePacijentaComponent } from './uputnice-pacijenta.component';

describe('UputnicePacijentaComponent', () => {
  let component: UputnicePacijentaComponent;
  let fixture: ComponentFixture<UputnicePacijentaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UputnicePacijentaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UputnicePacijentaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
