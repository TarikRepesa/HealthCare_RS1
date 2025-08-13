import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LijekoviComponent } from './lijekovi.component';

describe('LijekoviComponent', () => {
  let component: LijekoviComponent;
  let fixture: ComponentFixture<LijekoviComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LijekoviComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LijekoviComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
