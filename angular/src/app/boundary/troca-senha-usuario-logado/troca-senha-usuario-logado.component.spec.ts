import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TrocaSenhaUsuarioLogadoComponent } from './troca-senha-usuario-logado.component';

describe('TrocaSenhaUsuarioLogadoComponent', () => {
  let component: TrocaSenhaUsuarioLogadoComponent;
  let fixture: ComponentFixture<TrocaSenhaUsuarioLogadoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TrocaSenhaUsuarioLogadoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TrocaSenhaUsuarioLogadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
