import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagementAddComponent } from './management-add.component';

describe('ManagementAddComponent', () => {
  let component: ManagementAddComponent;
  let fixture: ComponentFixture<ManagementAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManagementAddComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManagementAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
