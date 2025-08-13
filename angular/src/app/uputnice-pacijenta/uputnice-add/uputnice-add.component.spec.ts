import { ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';
import { UputniceAddComponent } from './uputnice-add.component';

describe('UputniceAddComponent', () => {
  let component: UputniceAddComponent;
  let fixture: ComponentFixture<UputniceAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UputniceAddComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UputniceAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
