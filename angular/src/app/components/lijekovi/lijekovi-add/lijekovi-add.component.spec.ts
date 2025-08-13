import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LijekoviAddComponent } from './lijekovi-add.component';

describe('LijekoviAddComponent', () => {
  let component: LijekoviAddComponent;
  let fixture: ComponentFixture<LijekoviAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LijekoviAddComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LijekoviAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
