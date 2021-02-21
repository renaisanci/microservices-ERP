import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PessoaFilterServerComponent } from './pessoa-filter-server.component';

describe('PessoaFilterServerComponent', () => {
  let component: PessoaFilterServerComponent;
  let fixture: ComponentFixture<PessoaFilterServerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PessoaFilterServerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PessoaFilterServerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
