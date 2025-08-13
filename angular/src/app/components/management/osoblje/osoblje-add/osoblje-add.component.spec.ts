import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OsobljeAddComponent } from './osoblje-add.component';

describe('OsobljeAddComponent', () => {
  let component: OsobljeAddComponent;
  let fixture: ComponentFixture<OsobljeAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OsobljeAddComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OsobljeAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
