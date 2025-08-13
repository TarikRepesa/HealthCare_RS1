import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LijekoviEditComponent } from './lijekovi-edit.component';

describe('LijekoviEditComponent', () => {
  let component: LijekoviEditComponent;
  let fixture: ComponentFixture<LijekoviEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LijekoviEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LijekoviEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
