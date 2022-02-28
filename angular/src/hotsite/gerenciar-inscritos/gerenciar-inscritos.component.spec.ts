import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GerenciarInscritosComponent } from './gerenciar-inscritos.component';

describe('GerenciarInscritosComponent', () => {
  let component: GerenciarInscritosComponent;
  let fixture: ComponentFixture<GerenciarInscritosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GerenciarInscritosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GerenciarInscritosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
