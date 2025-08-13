import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OsobljeEditComponent } from './osoblje-edit.component';

describe('OsobljeEditComponent', () => {
  let component: OsobljeEditComponent;
  let fixture: ComponentFixture<OsobljeEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OsobljeEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OsobljeEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
