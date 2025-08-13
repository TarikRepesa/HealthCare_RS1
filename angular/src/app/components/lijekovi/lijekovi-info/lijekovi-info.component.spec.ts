import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LijekoviInfoComponent } from './lijekovi-info.component';

describe('LijekoviInfoComponent', () => {
  let component: LijekoviInfoComponent;
  let fixture: ComponentFixture<LijekoviInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LijekoviInfoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LijekoviInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
