import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NegociosFunilComponent } from './negocios-funil.component';

describe('NegociosFunilComponent', () => {
  let component: NegociosFunilComponent;
  let fixture: ComponentFixture<NegociosFunilComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NegociosFunilComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NegociosFunilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
