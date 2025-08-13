import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UputniceEditComponent } from './uputnice-edit.component';

describe('UputniceEditComponent', () => {
  let component: UputniceEditComponent;
  let fixture: ComponentFixture<UputniceEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UputniceEditComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UputniceEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
