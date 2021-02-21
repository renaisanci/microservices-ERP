import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NegociosMainComponent } from './negocios-main.component';

describe('NegociosMainComponent', () => {
  let component: NegociosMainComponent;
  let fixture: ComponentFixture<NegociosMainComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NegociosMainComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NegociosMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
