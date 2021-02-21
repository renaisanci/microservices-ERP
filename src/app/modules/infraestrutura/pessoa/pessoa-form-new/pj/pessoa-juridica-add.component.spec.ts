import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PessoaJuridicaAddComponent } from './pessoa-juridica-add.component';

describe('PessoaJuridicaAddComponent', () => {
  let component: PessoaJuridicaAddComponent;
  let fixture: ComponentFixture<PessoaJuridicaAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PessoaJuridicaAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PessoaJuridicaAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
