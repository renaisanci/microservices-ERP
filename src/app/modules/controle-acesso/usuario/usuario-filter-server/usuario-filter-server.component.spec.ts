import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UsuarioFilterServerComponent } from './usuario-filter-server.component';

describe('UsuarioFilterServerComponent', () => {
  let component: UsuarioFilterServerComponent;
  let fixture: ComponentFixture<UsuarioFilterServerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UsuarioFilterServerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UsuarioFilterServerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
