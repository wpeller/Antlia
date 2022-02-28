import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HotsiteLoginComponent } from './hotsite-login.component';

describe('HotsiteLoginComponent', () => {
  let component: HotsiteLoginComponent;
  let fixture: ComponentFixture<HotsiteLoginComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HotsiteLoginComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HotsiteLoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
